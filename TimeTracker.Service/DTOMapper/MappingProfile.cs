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

using TimeTracker.DTO.Staff;
using TimeTracker.Service.Services;
using TimeTracker.DTO.Systemsetting;
using TimeTracker.DTO.ChangejobDto;

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
           
            CreateMap<Staffstatus, StaffStatusDto>().ReverseMap();
            CreateMap<Systemsetting, SystemSettingDto>().ReverseMap();
            CreateMap<Userattendance, ChangejobDto>().ReverseMap();
            CreateMap<Systemsetting, ValidateIp>();
             CreateMap<Userattendance, HourListDto.Detail>()
            .ForMember(dest => dest.CheckInDateTime, opt => opt.MapFrom(src => src.CreatedOn));
            //CreateMap<Userattendance, HourListDto.Detail>()
            //.ForMember(dest => dest.CheckOutDateTime, opt => opt.MapFrom(src => src.CheckoutTime));

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDto>()
          .ForMember(dest => dest.LastStatus, opt => opt.MapFrom(src => src.UserAttendances.Status.Name));


        }
    }
}
