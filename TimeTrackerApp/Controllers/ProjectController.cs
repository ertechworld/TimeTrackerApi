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
        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync(string? querySearch)
        {
            var projectList = await _projectService.GetAll(querySearch);
            return Ok(projectList);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest(ModelState);
            }
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound(); 
            }
            return Ok(project);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] ProjectRequestDto projectRequestDto)
        {
            if (projectRequestDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Invalid !!!");
            }
            await _projectService.Add(projectRequestDto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProjectRequestDto projectUpdateDto)
        {
            if (projectUpdateDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Invalid");
            }
            var updatedValue = await _projectService.Update(id, projectUpdateDto);
            if (updatedValue == null)
            {
                return NotFound();
            }
            return Ok(updatedValue);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _projectService.Delete(id);
            return Ok();
        }
    }
}

