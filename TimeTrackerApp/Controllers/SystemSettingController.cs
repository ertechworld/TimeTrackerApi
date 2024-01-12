using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Systemsetting;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingController : ControllerBase
    {
        private readonly ISystemSettingService _systemSettingService;
      
        public SystemSettingController(ISystemSettingService systemSettingService)
        {
            _systemSettingService = systemSettingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var systemSettingList = await _systemSettingService.GetAll();
            return Ok(systemSettingList);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }

            var systemSetting = await _systemSettingService.GetById(id);

            if (systemSetting == null)
            {
                return NotFound("SystemSetting not found");
            }
            return Ok(systemSetting);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] SystemSettingDto systemSettingRequestDto)
        {
            if (systemSettingRequestDto == null)
            {
                return BadRequest("Request body is empty");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var addedSystemSetting = await _systemSettingService.Add(systemSettingRequestDto);
            if (addedSystemSetting == null)
            {
                return StatusCode(500, "Failed to add system setting");
            }
            return Ok(addedSystemSetting);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SystemSettingDto systemSettingUpdateDto)
        {
            if (systemSettingUpdateDto == null)
            {
                return BadRequest("Request body is empty");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var updatedSystemSetting = await _systemSettingService.Update(id, systemSettingUpdateDto);
            if (updatedSystemSetting == null)
            {
                return NotFound("SystemSetting not found");
            }
            return Ok(updatedSystemSetting);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
            await _systemSettingService.Delete(id);
            return Ok(true);
        }
    }
}