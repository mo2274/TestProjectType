using Microsoft.EntityFrameworkCore;
using ProjectType.Domain.Entities;

namespace ProjectType.Infrastructure.Data;

public class ProjectTypeDbContext : DbContext
{
    public ProjectTypeDbContext(DbContextOptions<ProjectTypeDbContext> options) : base(options)
    { }
    
    public DbSet<BusinessType> ProjectTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectTypeDbContext).Assembly);
    }
    
}