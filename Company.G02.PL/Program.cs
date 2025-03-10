using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repos;
using Company.G02.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); // Allow DI For DepartmentRepository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // Allow DI For DepartmentRepository

builder.Services.AddDbContext<CompanyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // Allow DI for CompanyDbContext
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
