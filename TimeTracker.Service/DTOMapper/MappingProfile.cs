using AutoMapper;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.User;
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
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserResponseDto>();

        }
    }
}
