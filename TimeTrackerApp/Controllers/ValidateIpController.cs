using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateIpController : ControllerBase
    {
        private readonly IValidateIpService _validateIpService;

        public ValidateIpController(IValidateIpService validateIpService)
        {
            _validateIpService = validateIpService;
        }

        [HttpGet("ValidateIpAddress")]
        public async Task<IActionResult> ValidateIpAddressAsync([FromQuery] string ipAddress)
        {
            try
            {
                var isValidIpAddress = await _validateIpService.ValidateIpAddressAsync(ipAddress);
                return Ok(isValidIpAddress);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}