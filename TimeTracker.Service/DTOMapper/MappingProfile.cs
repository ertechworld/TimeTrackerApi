using AutoMapper;
using TimeTracker.DTO.Product;
using TimeTracker.Service.Models;

namespace TimeTracker.Service.DTOMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRequestDto,Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductResponseDto>();

        }
    }
}
