using TimeTracker.DTO.Product;

namespace TimeTracker.Service.Services.IServices
{
    public interface IProjectService
    {
        IEnumerable<ProjectResponseDto> GetProjects();
        ProjectResponseDto GetProjectById(int id);
        void Add(ProjectRequestDto projectDto);
        void Update(ProjectUpdateDto projectDto);
        void Delete(int id);
    }
}
