using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAttendanceController : ControllerBase
    {
        private readonly IUserattendanceService _userattendanceService;
        public UserAttendanceController(IUserattendanceService userattendanceService, IMapper mapper)
        {
            _userattendanceService = userattendanceService;
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


    }
}
