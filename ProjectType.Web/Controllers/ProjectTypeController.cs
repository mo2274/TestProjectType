using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectType.Application.Dtos;
using ProjectType.Application.Services.ProjectType;
using ProjectType.Application.ViewModels;

namespace ProjectType.Web.Controllers;

public class ProjectTypeController : Controller
{
    private readonly IProjectTypeService _projectTypeService;
    private readonly IMapper _mapper;

   
    public ProjectTypeController(IProjectTypeService projectTypeService, IMapper mapper)
    {
        _projectTypeService = projectTypeService;
        _mapper = mapper;
    }
    
    public async Task<IActionResult> Index()
    {
        var projectTypes = await _projectTypeService.GetProjectTypes();
        
        var projectTypesModels = _mapper.Map<IEnumerable<ProjectTypeViewModel>>(projectTypes);
        
        return View(projectTypesModels);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectTypeViewModel projectType)
    {
        if (!ModelState.IsValid) 
            return View(projectType);
        
        var projectTypeDto = _mapper.Map<ProjectTypeDto>(projectType);
            
        await _projectTypeService.AddProjectType(projectTypeDto);
            
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var projectType = await _projectTypeService.GetProjectType(id);
        
        var projectTypeModel = _mapper.Map<ProjectTypeViewModel>(projectType);
            
        return View(projectTypeModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProjectTypeViewModel projectType)
    {
        if (!ModelState.IsValid) 
            return View(projectType);
        
        var projectTypeDto = _mapper.Map<ProjectTypeDto>(projectType);
            
        await _projectTypeService.UpdateProjectType(projectTypeDto.Id, projectTypeDto);
            
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        await _projectTypeService.DeleteProjectType(id);
        
        return RedirectToAction("Index");
    }
}