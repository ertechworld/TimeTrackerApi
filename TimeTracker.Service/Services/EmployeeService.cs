using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TimeTracker.DTO.Jobtype;
using TimeTracker.DTO.Status;
using TimeTracker.DTO.User;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
       
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _context.Users
                .Include(user => user.UserAttendances)
                    .ThenInclude(userAttendance => userAttendance.Status)
                .ToListAsync();
            var distinctUsers = users.Distinct().ToList();
            return distinctUsers.Select(user => _mapper.Map<User, UserDto>(user));
        }

    }

}
