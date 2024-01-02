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
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productService.GetProducts();
            return Ok(productList);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = _productService.GetProductById(id);
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Save([FromBody]ProductRequestDto productRequestDto)
        {
            if (productRequestDto == null)
                return BadRequest();
            if(!ModelState.IsValid) return BadRequest("Model Invalid !!!");
            _productService.Add(productRequestDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]ProductUpdateDto productUpdateDto) 
        {
            if(productUpdateDto == null)
                return BadRequest();
            if (!ModelState.IsValid) return BadRequest("Model Invalid");
            _productService.Update(productUpdateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return BadRequest();
            _productService.Delete(id);
            return Ok();
        }
    }
}
