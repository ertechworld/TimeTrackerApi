using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Data;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services.IServices;
using Task = TimeTracker.Service.Models.Task;

namespace TimeTracker.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TaskService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(TaskRequestDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            _context.Tasks.Add(task);
            _context.SaveChanges();
          
        }

        public void Delete(int id)
        {
            var taskInDb = _context.Tasks.Find(id);
            if (taskInDb != null)
                _context.Tasks.Remove(taskInDb);
            _context.SaveChanges();
        }

        public TaskRequestDto GetTaskById(int id)
        {
            Task task = _context.Tasks.Find(id);
            if (task != null)
            {
                return _mapper.Map<TaskRequestDto>(task);
            }
            return null;
        }

       
        public IEnumerable<TaskRequestDto> GetTasks()
        {
            return _context.Tasks.ToList().Select(_mapper.Map<Task, TaskRequestDto>);
        }

        public void Update(TaskRequestDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
