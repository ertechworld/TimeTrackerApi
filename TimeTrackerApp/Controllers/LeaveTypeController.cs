using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeavetypeService _leavetypeService;
        public LeaveTypeController(ILeavetypeService leavetypeService, IMapper mapper)
        {
            _leavetypeService = leavetypeService;
                
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {    
                var leavetypes = await _leavetypeService.GetAll();
                return Ok(leavetypes);          
        }

    }
}
