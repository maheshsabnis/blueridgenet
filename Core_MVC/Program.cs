using Core_MVC.Models;
using Core_MVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Lets register the DbContext and the Departmet and Employee Services
// 
/// THe BlueCompanyContext instance will be created for every new session
/// THis is Scopped Registertaion internally
builder.Services.AddDbContext<BlueCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});

// INitialize Session and Caching
builder.Services.AddSession();


// REgister Department and EMployee Services
builder.Services.AddScoped<IServices<Department,int>, DepartmentService>();
builder.Services.AddScoped<IServices<Employee,int>, EmployeeService>();


builder.Services.AddControllersWithViews();

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
app.UseSession(); // Session Middleare
app.UseRouting();

app.UseAuthorization();
// ROute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
