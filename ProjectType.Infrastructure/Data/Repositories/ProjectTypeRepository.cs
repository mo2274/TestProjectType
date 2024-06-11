using Microsoft.EntityFrameworkCore;
using ProjectType.Application.Dtos;
using ProjectType.Application.Interfaces.Repositories;
using ProjectType.Domain.Entities;

namespace ProjectType.Infrastructure.Data.Repositories;

public class ProjectTypeRepository : IProjectTypeRepository
{
    private readonly ProjectTypeDbContext _context;

    public ProjectTypeRepository(ProjectTypeDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProjectTypeDto>> GetProjectTypes() => await _context.ProjectTypes.Select(p => new ProjectTypeDto
        {
            Id = p.Id,
            Name = p.Name
        }).ToListAsync();

    public async Task<int> AddProjectType(BusinessType businessType)
    {
        _context.ProjectTypes.Add(businessType);
        return await _context.SaveChangesAsync();
    }

    public async Task<ProjectTypeDto> GetProjectType(int id) => await _context
        .ProjectTypes
        .Select(p => new ProjectTypeDto()
        {
            Id = p.Id,
            Name = p.Name
        })
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task UpdateProjectType(BusinessType existingProjectType)
    {
         _context.ProjectTypes.Update(existingProjectType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProjectType(BusinessType businessType)
    {
        _context.ProjectTypes.Remove(businessType);
        await _context.SaveChangesAsync();
    }
}