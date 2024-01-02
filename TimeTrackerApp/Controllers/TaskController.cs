using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Product;
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
        public IActionResult GetAll() { 
            var taskList= _taskService.GetTasks();
            return Ok(taskList);
        }
        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult Get(int id)
        {
            var tasks = _taskService.GetTaskById(id);
            return Ok(tasks);
        }
        [HttpPost("Add")]
        public IActionResult Save([FromBody] TaskRequestDto taskDto)
        {
            if (taskDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid !!!");
            _taskService.Add(taskDto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TaskRequestDto taskDto)
        { 
            if (taskDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid");
            _taskService.Update(taskDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            _taskService.Delete(id);
            return Ok();
        }
    }
}