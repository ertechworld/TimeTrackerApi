using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TimeTracker.DTO.User;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
       
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
           
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDto userRequestDto)
        {
            var user = await _userService.Login(userRequestDto);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }
        [HttpPost("Logout/{userId}")]
        public async Task<IActionResult> Logout(int userId)
        {
            var result = await _userService.Logout(userId);
            if (result)
            {
                return Ok(new { message = "Logout successful" });
            }
            else
            {
                return BadRequest(new { message = "Logout failed" });
            }
        }
    }
}
