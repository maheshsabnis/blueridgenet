using API_App.CustomMIddleware;
using API_App.MOdels;
using API_App.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BlueCompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConn"));
}); 

builder.Services.AddScoped<IService<Department,int>,DepartmentService>();
builder.Services.AddScoped<IService<Employee, int>, EmployeeService>();
// COnfigure Cross-Origin-Resource-SHaring (CORS) policy
// SO that on receiving the call from different Domain (Origin)
// Headers, or Method (HTTP Methods ) the API can provide Data Response 
builder.Services.AddCors(options => 
{
    options.AddPolicy("CORS", policy =>
    {
        // Allow all browser clients with all headers and all HTTP methods
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
       
    });
});

builder.Services.AddControllersWithViews();
// THis is for API Controllers
builder.Services.AddControllers().AddJsonOptions(options => 
{
    // Supress the DEfault Camel-Casing for JSON Response
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// API Test using Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // USed the Swagger in HTTP Pipeline to
    // Show Swagger UI Page to Test APIs
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS

app.UseCors("CORS");

app.UseAuthorization();


// Register the Custom Middleware
app.GlobalErrorHandler();

// Process the API Controller by Mapping it to the
// ROute Expression in HTTP REquest 
app.MapControllers();
// ROute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SPA}/{action=Index}/{id?}");
app.Run();
