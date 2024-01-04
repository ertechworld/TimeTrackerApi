using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobtypeService _jobtypeService;
        public JobTypeController(IJobtypeService jobtypeService, IMapper mapper)
        {
            _jobtypeService = jobtypeService;
                
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {    
                var jobtypes = await _jobtypeService.GetAll();
                return Ok(jobtypes);          
        }

    }
}
