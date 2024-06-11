using AutoMapper;
using ProjectType.Application.Dtos;
using ProjectType.Application.ViewModels;
using ProjectType.Domain.Entities;

namespace ProjectType.Application.MappingProfiles;

public class ProjectTypeProfile : Profile
{
    public ProjectTypeProfile()
    {
        CreateMap<BusinessType, ProjectTypeDto>()
            .ReverseMap();
        
        CreateMap<ProjectTypeViewModel, ProjectTypeDto>()
            .ReverseMap();
    }
}