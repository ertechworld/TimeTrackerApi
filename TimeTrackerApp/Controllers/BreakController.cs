using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakController : ControllerBase
    {
        private readonly IBreakService _breakService;
        public BreakController(IBreakService breakService)
        {
              
            _breakService = breakService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var jobtypes = await _breakService.GetAll();
            return Ok(jobtypes);
        }
    }
}
