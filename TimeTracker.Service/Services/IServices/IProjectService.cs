using TimeTracker.DTO.Project;

namespace TimeTracker.Service.Services.IServices
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectResponseDto>> GetAll(string? querySearch);

        Task<ProjectRequestDto> GetById(int id);
        Task<bool> Add(ProjectRequestDto projectDto);
        Task<ProjectRequestDto> Update(int id, ProjectRequestDto projectDto);
        Task<ProjectRequestDto> Delete(int id);

    }
}

