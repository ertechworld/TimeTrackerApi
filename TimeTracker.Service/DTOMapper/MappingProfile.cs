using AutoMapper;
using TimeTracker.DTO.Leave;
using TimeTracker.DTO.Leavetype;
using TimeTracker.DTO.Status;
using TimeTracker.DTO.Task;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Entities;
using TimeTracker.DTO.User;
using TimeTracker.DTO.Project;
using TimeTracker.DTO.Jobtype;
using Task = TimeTracker.Service.Entities.Task;
using TimeTracker.DTO.Break;

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
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Userattendance, UserattendanceDto>().ReverseMap();
            CreateMap<Jobtype, JobtypeDto>().ReverseMap();    
            CreateMap<Leavetype, LeavetypeDto>().ReverseMap();
            CreateMap<Leave,LeaveRequestDto>().ReverseMap();
            CreateMap<Leave, LeaveResponseDto>().ReverseMap();
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserResponseDto>();
            CreateMap<Userattendance,HourListDto>().ReverseMap();
            CreateMap<Break ,BreakDto>().ReverseMap();
        }
    }
}
