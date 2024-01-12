using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Data;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserattendanceService _userattendanceService;
        public UserAttendanceController(IUserattendanceService userattendanceService, IMapper mapper, ApplicationDbContext context)
        {
            _userattendanceService = userattendanceService;
            _context=context;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] UserattendanceDto userattendanceDto)
        {
            if (userattendanceDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Invalid !!!");
            }
            await _userattendanceService.Add(userattendanceDto);
            return Ok(true);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserattendanceDto userattendanceDto)
        {
            if (userattendanceDto == null)
            {
                return BadRequest("Request body is empty");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }

            var userattendance = await _userattendanceService.Update(id, userattendanceDto);

            if (userattendance == null)
            {
                return NotFound("Userattendance not found");
            }

            return Ok(userattendance);
        }
        [HttpGet("GetByUserIdAndWeekId")]
        public async Task<ActionResult<IEnumerable<HourListDto>>> GetByUserIdAndWeekId([FromQuery] int userId, [FromQuery] int weekId, [FromQuery] int year)
        {
            try
            {
                var result = await _userattendanceService.GetByUserIdAndWeekId(userId, weekId, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

