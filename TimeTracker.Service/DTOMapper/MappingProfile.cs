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
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.Staff;
using TimeTracker.Service.Services;
using TimeTracker.DTO.Systemsetting;

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
            CreateMap<Userattendance, HourListDto.Detail>();
            CreateMap<Userattendance, HourListDto>();
            CreateMap<Break ,BreakDto>().ReverseMap();
            CreateMap<User, EmployeeDto>().ReverseMap();
            CreateMap<Staffstatus, StaffStatusDto>().ReverseMap();
            CreateMap<Systemsetting, SystemSettingDto>().ReverseMap();
            CreateMap<Systemsetting, ValidateIp>();
             CreateMap<Userattendance, HourListDto.Detail>()
            .ForMember(dest => dest.CheckingInTime, opt => opt.MapFrom(src => src.CreatedOn));
        }
    }
}
