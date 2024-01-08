using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeTracker.DTO.Task;

namespace TimeTracker.Service.Services.IServices
{
    public interface ITaskService
    {
       Task< IEnumerable<TaskResponseDto>> GetAll(string? querySearch);
       Task< TaskRequestDto> GetById(int id);
        Task<TaskRequestDto> Add(TaskRequestDto taskDto);
        Task<TaskRequestDto> Update(int id,TaskRequestDto taskDto);
        Task<TaskRequestDto> Delete(int id);
        Task<IEnumerable<TaskResponseDto>> GetByProjectId(int projectId);

    }
}
