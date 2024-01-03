using AutoMapper;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Models;
using Task = TimeTracker.Service.Models.Task;

namespace TimeTracker.Service.DTOMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Project, ProjectRequestDto>().ReverseMap();
            CreateMap<Project, ProjectResponseDto>().ReverseMap();
            CreateMap<Task, TaskRequestDto>().ReverseMap();
            CreateMap<Task, TaskResponseDto>().ReverseMap();

        }
    }
}
