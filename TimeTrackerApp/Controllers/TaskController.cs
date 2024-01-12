using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService,IMapper mapper)
        {
                _taskService= taskService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync(string? querySearch)
        {
            var taskList = await _taskService.GetAll(querySearch);
            return Ok(taskList);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var task = await _taskService.GetById(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound(true); 
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] TaskRequestDto taskDto)
        {
            if (taskDto == null)
            {        
                return BadRequest(false);
            }
            if (!ModelState.IsValid)
            {              
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(new { Success = false, Errors = errors });
            }
              await _taskService.Add(taskDto);
              return Ok(new { Success = true });   
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] TaskRequestDto taskDto)
        {
            var updatedValue = await _taskService.Update(id, taskDto);
            if (updatedValue == null)
            {
                return NotFound(); 
            }
            return Ok(updatedValue);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();
            await _taskService.Delete(id);
            return Ok(true);
        }
        [HttpGet("GetByProjectId/{projectId}")]
        public async Task<IActionResult> GetByProjectId(int projectId)
        {
                var tasks = await _taskService.GetByProjectId(projectId);
                if (tasks == null || !tasks.Any())
                {
                    return NotFound($"No tasks found for project ID {projectId}");
                }
                return Ok(tasks);
        }
    }
}