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
        public async Task<TaskRequestDto> Add(TaskRequestDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskRequestDto>(task);
        }
        public async Task<TaskRequestDto> Delete(int id)
        {
            Task task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                task.IsDeleted = true;
                await _context.SaveChangesAsync();
                return _mapper.Map<TaskRequestDto>(task);  
            }
            return null; 
        }
        public async Task<TaskRequestDto> GetById(int id)
        {
            Task task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                return _mapper.Map<TaskRequestDto>(task);
            }
            return null;
        }
        public async Task<IEnumerable<TaskResponseDto>> GetAll(string? querySearch)
        {
            var query = _context.Tasks.Where(x => x.IsDeleted != true);
            if (!string.IsNullOrEmpty(querySearch))
            {
                query = query.Where(x => x.Name.Contains(querySearch));
            }
            var tasks = await query.ToListAsync();
            return tasks.Select(task => _mapper.Map<Task, TaskResponseDto>(task));
        }
        public async Task<TaskRequestDto> Update(int id, TaskRequestDto taskDto)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask != null)
            {
                _mapper.Map(taskDto, existingTask);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<TaskRequestDto>(existingTask);
        }
    }
}

