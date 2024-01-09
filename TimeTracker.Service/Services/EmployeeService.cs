using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.Jobtype;
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
            var query = _context.Employees
             
           .Where(x => x.IsDeleted != true);
            if (!string.IsNullOrEmpty(querySearch))
            {
                query = query.Where(x =>
                    x.FirstName.Contains(querySearch) ||
                    x.LastName.Contains(querySearch) ||
                    x.Email.Contains(querySearch)
                );
            }
            var employees = await query.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
        

    }

}
