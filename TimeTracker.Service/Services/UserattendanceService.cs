using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class UserattendanceService:IUserattendanceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserattendanceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserattendanceDto> Add(UserattendanceDto userattendanceDto)
        {
            var userattendance = _mapper.Map<Userattendance>(userattendanceDto);
            await _context.Userattendances.AddAsync(userattendance);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserattendanceDto>(userattendance);
        }

        public async Task<UserattendanceDto> Update(int id, UserattendanceDto userattendanceDto)
        {
            var userattendance = await _context.Userattendances.FindAsync(id);
            if (userattendance != null)
            {
                _mapper.Map(userattendanceDto, userattendance);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<UserattendanceDto>(userattendance);
        }

        public async Task<IEnumerable<HourListDto>> GetByUserIdAndWeekId(int userId, int weekId)
        {
            IQueryable<Userattendance> query = _context.Userattendances
                .Include(u => u.Status)
                .Include(u => u.JobType)
                .Include(u => u.Project)
                .Include(u => u.Task)
                .Include(u => u.User);
            query = query.Where(u => u.UserId == userId);
            if (weekId > 0)
            {  
                query = query.Where(u => u.CreatedOn.HasValue);  
                var userHourList = await query.OrderBy(u => u.CreatedOn).ToListAsync();
                userHourList = userHourList
                    .Where(u => GetWeekInfo(u.CreatedOn).WeekId == weekId)
                    .ToList();
                var hourListDto = new HourListDto
                {
                    Details = _mapper.Map<List<HourListDto.Detail>>(userHourList),
                };

                // Get WeekInfo based on the CheckingInTime of the first entry
                var weekInfo = GetWeekInfo(userHourList.FirstOrDefault()?.CreatedOn);

                // Set WeekId and WeekStart/WeekEnd in each Detail object
                foreach (var detail in hourListDto.Details)
                {
                    detail.WeekId = weekInfo.WeekId;
                    detail.WeekStart = weekInfo.StartTime;
                    detail.WeekEnd = weekInfo.EndTime;
                }
                int targetYear = weekInfo.StartTime.Year;
                hourListDto.Details = hourListDto.Details
                    .Where(detail => detail.CheckInTime?.Year == targetYear)
                    .ToList();
                hourListDto.CalculateTotalDuration();
                return new List<HourListDto> { hourListDto };
            }
            // Continue without weekId filtering
            var userHourListWithoutWeekFilter = await query.OrderBy(u => u.CreatedOn).ToListAsync();
            var hourListDtoWithoutWeekFilter = new HourListDto
            {
                Details = _mapper.Map<List<HourListDto.Detail>>(userHourListWithoutWeekFilter),
            };
            return new List<HourListDto> { hourListDtoWithoutWeekFilter };
        }
        private (int WeekId, DateTime StartTime, DateTime EndTime) GetWeekInfo(DateTime? date)
        {
            if (date.HasValue)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                DateTime startOfWeek = date.Value.Date.AddDays(-(int)date.Value.DayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
                int weekId = cal.GetWeekOfYear(date.Value, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                return (weekId, startOfWeek, endOfWeek);
            }
            return (0, DateTime.MinValue, DateTime.MinValue); // Default values if date is null
        }


    }
}





