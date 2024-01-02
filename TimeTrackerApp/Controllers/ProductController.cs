using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Product;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllProducts()
        {
            var productList = _productService.GetProducts();
            return Ok(productList);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id == 0) return BadRequest(ModelState);
            var products = _productService.GetProductById(id);
            return Ok(products);
        }
        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody]ProductRequestDto productRequestDto)
        {
            if (productRequestDto == null)
                return BadRequest();
            if(!ModelState.IsValid) return BadRequest("Model Invalid !!!");
            _productService.Add(productRequestDto);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody]ProductUpdateDto productUpdateDto) 
        {
            if(productUpdateDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid");
            _productService.Update(productUpdateDto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if(id == 0)
                return BadRequest();
            _productService.Delete(id);
            return Ok();
        }
    }
}
