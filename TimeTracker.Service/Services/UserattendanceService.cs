using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<HourListDto>> GetHourList()
        {
            var allUserHourList = await _context.Userattendances
                .Include(u => u.Status)
                .Include(u => u.JobType)
                .Include(u => u.Project)
                .Include(u => u.Task)
                .Include(u=>u.User)
                .OrderBy(u => u.CreatedOn)
                .ToListAsync();

            return allUserHourList.Select(userattendance => _mapper.Map<Userattendance, HourListDto>(userattendance));
        }


        public async Task<IEnumerable<HourListDto>> GetHourListByUserId(int userId)
        {
            var userHourList = await _context.Userattendances
                .Include(u => u.Status)
                .Include(u => u.JobType)
                .Include(u => u.Project)
                .Include(u => u.Task)
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.CreatedOn)
                .ToListAsync();

            return userHourList.Select(userattendance => _mapper.Map<Userattendance, HourListDto>(userattendance));
        }


    }

}

