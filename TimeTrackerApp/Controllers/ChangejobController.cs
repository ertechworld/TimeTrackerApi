using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.ChangejobDto;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ChangejobController : ControllerBase
    {
        private readonly IChangejobService _changejobService;
        public ChangejobController(IChangejobService changejobService)
        {
            _changejobService = changejobService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ChangejobDto changejobDto)
        {
            if (changejobDto == null)
            {
                return BadRequest(false);
            }
            var success = await _changejobService.Update(id, changejobDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }    
 }

