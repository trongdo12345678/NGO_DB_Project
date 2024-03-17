using Microsoft.EntityFrameworkCore;
using NGO_DB_Project.Models;
using NGO_DB_Project.Models.ClassImpl;
using NGO_DB_Project.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GiveAidContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//caaus hinh khi tao project moi
builder.Services.AddScoped<ProjectypeService, ProjectTypeServiceImpl>();
builder.Services.AddScoped<ProjectService, ProjectServicempl>();
builder.Services.AddScoped<MemberService, MemberServicempl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
	name: "Admin",
	pattern: "{area:exists}/{controller}/{action}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");
app.MapControllerRoute(
  name: "default",
  pattern: "{controller}/{action=Index}/{page?}"
);

app.Run();
