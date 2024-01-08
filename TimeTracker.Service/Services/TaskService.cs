using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Data;
using TimeTracker.Service.Services.IServices;
using Task = TimeTracker.Service.Entities.Task;

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
            var query = _context.Tasks
                .Include(t => t.Project)
                .Where(t => t.IsDeleted != true);
            if (!string.IsNullOrEmpty(querySearch))
            {
                query = query.Where(t => t.Name.Contains(querySearch));
            }
            var tasks = await query.ToListAsync();
            return tasks.Select(task => _mapper.Map<Task, TaskResponseDto>(task));
        }
        public async Task<TaskRequestDto> Update(int id, TaskRequestDto taskDto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _mapper.Map(taskDto, task);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<TaskRequestDto>(task);
        }
        public async Task<IEnumerable<TaskResponseDto>> GetByProjectId(int projectId)
        {
            var tasks = await _context.Tasks.Where(task => task.ProjectId == projectId && task.IsDeleted == false).ToListAsync();
            return tasks.Select(task => _mapper.Map<Task, TaskResponseDto>(task));
        }
    }
}

