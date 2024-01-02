using AutoMapper;
using TimeTracker.DTO.Product;
using TimeTracker.Service.Data;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ProductRequestDto productRequestDto)
        {
            var product = _mapper.Map<Product>(productRequestDto);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productInDb = _context.Products.Find(id);
            if (productInDb != null)
                _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }

        public ProductResponseDto GetProductById(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                return _mapper.Map<ProductResponseDto>(product);
            }
            return null;
        }

        public IEnumerable<ProductResponseDto> GetProducts()
        {
            return _context.Products.ToList().Select(_mapper.Map<Product, ProductResponseDto>);
        }
        public void Update(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            _context.Products.Update(product);
            _context.SaveChanges();
        }


    }
}
