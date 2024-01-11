using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.Jobtype;
using TimeTracker.DTO.Status;
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
       
        public async Task<IEnumerable<EmployeeDto>> GetAll(string? querySearch)
        {
            var query = _context.Users
                .Include(employee => employee.Userattendance)
                    .ThenInclude(userattendance => userattendance.Status)
                .Where(x => x.IsDeleted==false);
            if (!string.IsNullOrEmpty(querySearch))
            {
                query = query.Where(employee =>
                    employee.FirstName.Contains(querySearch) ||
                    employee.LastName.Contains(querySearch) ||
                    employee.Email.Contains(querySearch)
                );
            }
            var employees = await query.ToListAsync();
            var employeeDtoList = employees.Select(employee => new EmployeeDto
            { 
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName, 
                UserattendanceStatusName = employee.Userattendance?.Status?.Name
            }).ToList();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeeDtoList);
        }
    }

}
