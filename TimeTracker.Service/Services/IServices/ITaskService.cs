using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Task;

namespace TimeTracker.Service.Services.IServices
{
    public interface ITaskService
    {
        IEnumerable<TaskRequestDto> GetTasks();
        TaskRequestDto GetTaskById(int id);
        void Add(TaskRequestDto taskDto);
        void Update(TaskRequestDto taskDto);
        void Delete(int id);
    }
}
