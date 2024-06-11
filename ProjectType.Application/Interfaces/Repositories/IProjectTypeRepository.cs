using ProjectType.Application.Dtos;
using ProjectType.Domain.Entities;

namespace ProjectType.Application.Interfaces.Repositories;

public interface IProjectTypeRepository
{
    Task<IEnumerable<ProjectTypeDto>> GetProjectTypes();
    Task<int> AddProjectType(BusinessType businessType);
    Task<ProjectTypeDto> GetProjectType(int id);
    Task UpdateProjectType(BusinessType existingProjectType);
    Task DeleteProjectType(BusinessType businessType);
}