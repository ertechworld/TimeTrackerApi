using TimeTracker.DTO.Product;

namespace TimeTracker.Service.Services.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetProducts();
        ProductResponseDto GetProductById(int id);
        void Add(ProductRequestDto productDto);
        void Update(ProductUpdateDto productDto);
        void Delete(int id);
    }
}
