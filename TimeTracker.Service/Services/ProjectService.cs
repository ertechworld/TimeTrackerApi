using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TimeTracker.DTO.Project;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Add(ProjectRequestDto projectDto)
        {
                var project = _mapper.Map<Project>(projectDto);
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
                return true;
        }
        public async Task<ProjectRequestDto> Delete(int id)
        {
            Project project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                project.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<ProjectRequestDto>(project);
        }
        public async Task<ProjectRequestDto> GetById(int id)
        {
            Project project = await _context.Projects.FindAsync(id);
            return _mapper.Map<ProjectRequestDto>(project);   
        }
        public async Task<IEnumerable<ProjectResponseDto>> GetAll(string? querySearch)
        {
            var query = _context.Projects.Where(x => x.IsDeleted != true);
            if (!string.IsNullOrEmpty(querySearch))
            {
                query = query.Where(x => x.Name.Contains(querySearch));
            }
            var projects = await query.ToListAsync();
            return projects.Select(project => _mapper.Map<Project, ProjectResponseDto>(project));
        }
        public async Task<ProjectRequestDto> Update(int id, ProjectRequestDto projectUpdateDto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _mapper.Map(projectUpdateDto, project);
                await _context.SaveChangesAsync(); 
            }
            return _mapper.Map<ProjectRequestDto>(project);
        }
    }
}

