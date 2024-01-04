using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var projectList = await _statusService.GetAll();
            return Ok(projectList);
        }
    }
}
