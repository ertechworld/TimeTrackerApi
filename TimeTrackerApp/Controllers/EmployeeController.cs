using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TimeTracker.DTO.User;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;

        }
       
       
        [HttpGet("GetAll")]
      
        public async Task<IActionResult> GetAllUsers(string? querySearch)
        {
            try
            {
                var userDtos = await _employeeService.GetAllUsers(querySearch);
                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
