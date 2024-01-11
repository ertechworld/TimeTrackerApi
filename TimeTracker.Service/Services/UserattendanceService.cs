using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DTO.Break;
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

        public async Task<IEnumerable<HourListDto>> GetHourListbyId(int userId, int statusId)
        {
            var userHourList = await _context.Userattendances
                .Include(u => u.Status)
                .Include(u => u.JobType)
                .Include(u => u.Project)
                .Include(u => u.Task)
                .Include(u => u.User)
                .Include(u => u.Break)
                .Where(u => u.UserId == userId && u.StatusId == statusId)
                .OrderBy(u => u.CreatedOn)
                .ToListAsync();
            var hourListDto = new HourListDto
            {
                Details = _mapper.Map<List<HourListDto.Detail>>(userHourList),
            };
            hourListDto.CalculateTotalDuration();
            return new List<HourListDto> { hourListDto };
        }

    }

}

