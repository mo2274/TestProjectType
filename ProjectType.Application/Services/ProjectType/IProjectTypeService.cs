using ProjectType.Application.Dtos;

namespace ProjectType.Application.Services.ProjectType;

public interface IProjectTypeService
{
    Task<IEnumerable<ProjectTypeDto>> GetProjectTypes();
    Task AddProjectType(ProjectTypeDto projectType);
    Task UpdateProjectType(int id, ProjectTypeDto projectType);
    Task DeleteProjectType(int id);
    Task<ProjectTypeDto> GetProjectType(int id);
}