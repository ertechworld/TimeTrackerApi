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
            CreateMap<ProjectRequestDto,Project>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<Task, TaskRequestDto>().ReverseMap();
            CreateMap<Task, TaskResponseDto>().ReverseMap();

        }
    }
}
