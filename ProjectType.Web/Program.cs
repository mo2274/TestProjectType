using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjectType.Application.Interfaces.Repositories;
using ProjectType.Application.MappingProfiles;
using ProjectType.Application.Services.ProjectType;
using ProjectType.Infrastructure.Data;
using ProjectType.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ProjectTypeProfile)));
builder.Services
    .AddDbContext<ProjectTypeDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IProjectTypeService, ProjectTypeService>();
builder.Services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ProjectType}/{action=Index}/{id?}");

    endpoints.MapControllers(); 
});

app.Run();