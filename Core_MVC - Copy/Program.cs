using Core_MVC.CustomFilters;
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

// The Reqyuest will be accepetd for
// MVC and API Controller
// THis will load and initialize all dependencies for MVC and API COntrollers
// ALl MVC Depednecies are defined in  'MvcOptions' class
// e.g. ModelMetedata, Filters, etc
builder.Services.AddControllersWithViews(options => 
{ 
    // Filter Registered at Global Levele
    // THis will be applicable only for MVC and API Controllers
    // If the same application uses Razor Pageg (In case of Identity)
    // then Globally applied FIlters will crash, better apply them
    // on COntrollers
    options.Filters.Add(new LoggerFilterAttribute());
    // register the exception filter
    // AUto-REsolve the IMOdelMetadataProvider from MvcOptions 
    options.Filters.Add(typeof(CustomExceptionFilter));
});

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
