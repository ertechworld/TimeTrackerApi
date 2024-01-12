using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Project;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   [Authorize]
    [Authorize(Roles = "Admin,Leiðari")]
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
        public async Task<IActionResult> Add([FromBody] ProjectRequestDto projectRequestDto)
        {
            if (projectRequestDto == null)
            {
                return BadRequest("Request body is empty");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
             bool isAdded = await _projectService.Add(projectRequestDto);
             if (isAdded)
             {
                    return Ok("Project added successfully");
             }
             else
             {
                    return StatusCode(500, "Failed to add project");
              }    
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
            return Ok(true);
        }
    }
}

