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
        [HttpGet("GetAll")]
        public IActionResult GetAllProducts()
        {
            var productList = _projectService.GetProjects();
            return Ok(productList);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id == 0) return BadRequest(ModelState);
            var products = _productService.GetProductById(id);
            return Ok(products);
            var projects = _projectService.GetProjectById(id);
            return Ok(projects);
        }
        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody]ProductRequestDto productRequestDto)
        {
            if (projectRequestDto == null)
                return BadRequest();
            if(!ModelState.IsValid) return BadRequest("Model Invalid !!!");
            _projectService.Add(projectRequestDto);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody]ProductUpdateDto productUpdateDto) 
        {
            if(projectUpdateDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid");
            _projectService.Update(projectUpdateDto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if(id == 0)
                return BadRequest();
            _projectService.Delete(id);
            return Ok();
        }
    }
}
