using AutoMapper;
using TimeTracker.DTO.Product;
using TimeTracker.Service.Data;
using TimeTracker.Service.Models;
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

        public void Add(ProjectRequestDto projectRequestDto)
        {
            var product = _mapper.Map<Project>(projectRequestDto);
            _context.Projects.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productInDb = _context.Projects.Find(id);
            if (productInDb != null)
                _context.Projects.Remove(productInDb);
            _context.SaveChanges();
        }

        public ProjectResponseDto GetProjectById(int id)
        {
            Project product = _context.Projects.Find(id);
            if (product != null)
            {
                return _mapper.Map<ProjectResponseDto>(product);
            }
            return null;
        }

        public IEnumerable<ProjectResponseDto> GetProjects()
        {
            return _context.Projects.ToList().Select(_mapper.Map<Project, ProjectResponseDto>);
        }
        public void Update(ProjectUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Project>(productUpdateDto);
            _context.Projects.Update(product);
            _context.SaveChanges();
        }


    }
}
