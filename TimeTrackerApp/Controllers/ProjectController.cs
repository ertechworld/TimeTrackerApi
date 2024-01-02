using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Product;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _projectService.GetProjects();
            return Ok(productList);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var projects = _projectService.GetProjectById(id);
            return Ok(projects);
        }
        [HttpPost]
        public IActionResult Save([FromBody]ProjectRequestDto projectRequestDto)
        {
            if (projectRequestDto == null)
                return BadRequest();
            if(!ModelState.IsValid) return BadRequest("Model Invalid !!!");
            _projectService.Add(projectRequestDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]ProjectUpdateDto projectUpdateDto) 
        {
            if(projectUpdateDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid");
            _projectService.Update(projectUpdateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return BadRequest();
            _projectService.Delete(id);
            return Ok();
        }
    }
}
