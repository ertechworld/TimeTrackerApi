using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Leave;

using TimeTracker.DTO.Task;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface ILeaveService
    {
       Task< IEnumerable<LeaveResponseDto>> GetAll();
       Task<LeaveRequestDto> GetById(int id);
        Task<LeaveRequestDto> Add(LeaveRequestDto leaveDto);
        Task<LeaveRequestDto> Update(int id, LeaveRequestDto leaveDto);
        Task<LeaveRequestDto> Delete(int id);
        Task<IEnumerable<LeaveResponseDto>> GetAllByUserId(int userId);



    }
}
