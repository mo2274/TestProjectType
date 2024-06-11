using System.ComponentModel.DataAnnotations;

namespace ProjectType.Application.Dtos;

public class ProjectTypeDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}