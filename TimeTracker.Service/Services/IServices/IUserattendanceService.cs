using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using TimeTracker.DTO.Status;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface IUserattendanceService
    {
        Task<UserattendanceDto> Add(UserattendanceDto userattendanceDto);
        Task<UserattendanceDto> Update(int id, UserattendanceDto userattendanceDto);
        Task<IEnumerable<HourListDto>> GetHourList();
        Task<IEnumerable<HourListDto>> GetHourListByUserId(int userId);
      
    }
}
