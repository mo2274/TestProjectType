using Microsoft.AspNetCore.Mvc;
using ProjectType.Application.Dtos;
using ProjectType.Application.Services.ProjectType;

namespace ProjectType.Web.Controllers.Apis;

[ApiController]
[Route("api/[controller]")]
public class ProjectTypesController : ControllerBase
{
    private readonly IProjectTypeService _projectTypeService;

    public ProjectTypesController(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProjectTypes()
    {
        var projectTypes = await _projectTypeService.GetProjectTypes();
        
        return Ok(projectTypes);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProjectType(ProjectTypeDto projectType)
    {
        await _projectTypeService.AddProjectType(projectType);
        
        return Ok("Project Type added successfully");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectType(int id, ProjectTypeDto projectType)
    {
        try
        {
            await _projectTypeService.UpdateProjectType(id, projectType);
        
            return Ok("Project Type updated successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProjectType(int id)
    {
        try
        {
            await _projectTypeService.DeleteProjectType(id);
        
            return Ok("Project Type deleted successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}