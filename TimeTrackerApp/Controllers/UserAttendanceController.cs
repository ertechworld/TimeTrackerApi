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
        [HttpGet("GetHourList")]
        public async Task<IActionResult> GetHourList()
        {
            var hourList = await _userattendanceService.GetHourList();
            return Ok(hourList);
        }

        [HttpGet("GetHourListByUserId/{userId}")]
        public async Task<IActionResult> GetHourListByUserId(int userId)
        {
            var hourListByUserId = await _userattendanceService.GetHourListByUserId(userId);

            if (hourListByUserId == null || !hourListByUserId.Any())
            {
                return NotFound($"No hour list found for user ID {userId}");
            }

            return Ok(hourListByUserId);
        }
        [HttpGet("get-hour-list/{userId}")]
        public async Task<IActionResult> GetHourListWithBreakHoursAsync(int userId)
        {
            try
            {
                var hourListWithBreaks = await _userattendanceService.GetHourListWithBreakHoursAsync(userId);
                return Ok(hourListWithBreaks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task<IActionResult> GetBreakHoursAsync(int userAttendanceId)
        {
            try
            {
                var breakHours = await _userattendanceService.GetBreakHoursAsync(userAttendanceId);
                return Ok(breakHours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

