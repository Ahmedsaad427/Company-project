using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repos;
using Company.G02.DAL.Data.Contexts;
using Company.G02.PL.Mapping;
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

builder.Services.AddAutoMapper(typeof(EmployeeProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Life Time
//builder.Services.AddScoped();    // Create Object Life Time Per Request - UnReachable Object
//builder.Services.AddTransient(); // Create Object Life Time Per Operation
//builder.Services.AddSingleton(); // Create Object Life Timer Per App


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
