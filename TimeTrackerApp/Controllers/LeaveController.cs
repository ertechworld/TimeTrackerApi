using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Leave;

using TimeTracker.DTO.Task;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService,IMapper mapper)
        {
            _leaveService = leaveService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var leaveList = await _leaveService.GetAll();
            return Ok(leaveList);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var leave = await _leaveService.GetById(id);
            if (leave != null)
            {
                return Ok(leave);
            }
            return NotFound(true); 
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] LeaveRequestDto leaveDto)
        {
            if (leaveDto == null)
            {
                return BadRequest(false);
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(new { Success = false, Errors = errors });
            }    
             await _leaveService.Add(leaveDto);
             return Ok(new { Success = true });        
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] LeaveRequestDto leaveDto)
        {
            var updatedValue = await _leaveService.Update(id, leaveDto);
            if (updatedValue == null)
            {
                return NotFound(); 
            }
            return Ok(updatedValue);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();
            await _leaveService.Delete(id);
            return Ok(true);
        }
        [HttpGet("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var leaves = await _leaveService.GetAllByUserId(userId);

            if (leaves == null || !leaves.Any())
            {
                return NotFound($"No leaves found for user ID {userId}");
            }
            return Ok(leaves);
        }
    }
}