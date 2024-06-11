using AutoMapper;
using ProjectType.Application.Dtos;
using ProjectType.Application.Interfaces.Repositories;
using ProjectType.Domain.Entities;

namespace ProjectType.Application.Services.ProjectType;

public class ProjectTypeService : IProjectTypeService
{
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IMapper _mapper;

    public ProjectTypeService(IProjectTypeRepository projectTypeRepository, IMapper mapper)
    {
        _projectTypeRepository = projectTypeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectTypeDto>> GetProjectTypes() => await _projectTypeRepository.GetProjectTypes();
    
    public async Task AddProjectType(ProjectTypeDto projectType)
    {
        var businessType = _mapper.Map<BusinessType>(projectType);
        await _projectTypeRepository.AddProjectType(businessType);
    }

    public async Task UpdateProjectType(int id, ProjectTypeDto projectType)
    {
        var existingProjectType = await _projectTypeRepository.GetProjectType(id);
        
        if (existingProjectType == null)
            throw new Exception("Project Type not found");

        var businessType = _mapper.Map<BusinessType>(projectType);
        
        await _projectTypeRepository.UpdateProjectType(businessType);
    }

    public async Task DeleteProjectType(int id)
    {
        var existingProjectType = await _projectTypeRepository.GetProjectType(id);
        
        if (existingProjectType == null)
            throw new Exception("Project Type not found");

        var businessType = _mapper.Map<BusinessType>(existingProjectType);
        
        await _projectTypeRepository.DeleteProjectType(businessType);
    }

    public async Task<ProjectTypeDto> GetProjectType(int id)
    {
        return await _projectTypeRepository.GetProjectType(id);
    }
}