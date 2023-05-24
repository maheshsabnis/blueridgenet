using Core_MVC.CustomFilters;
using Core_MVC.Models;
using Core_MVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Core_MVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. REgister SecurityDbDContext

builder.Services.AddDbContext<Core_MVCContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecureConn"));
});

// 2. REgister Identity Object Model for Users and Roles
// THis will Register UserManager<IdentityUser>, RoleManager<IdentityRole>, and SignInManager<IdentityUser>
// in the DI Container
builder.Services.
        AddIdentity<IdentityUser,IdentityRole>()
        // USe the Security Database for SToring USers and ROles Information
        .AddEntityFrameworkStores<Core_MVCContext>().AddDefaultUI(); // or DEfault Identity UI


// 3. Add the AUthentication Service
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("ReadPolicy", policy => 
    {
        policy.RequireRole("Manager","Clerk","Operator");
    });
    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("Manager","Clerk");
    });
    options.AddPolicy("EditDeletePolicy", policy =>
    {
        policy.RequireRole("Manager");
    });
});

// Lets register the DbContext and the Departmet and Employee Services
// 
/// THe BlueCompanyContext instance will be created for every new session
/// THis is Scopped Registertaion internally
builder.Services.AddDbContext<BlueCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Core_MVCContext>();
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
    //NOTE: DO NOT USE FILTERS AT GLOBAL LEVEL IF THE APP HAS RAZOR VIEWS
    // Filter Registered at Global Levele
    // THis will be applicable only for MVC and API Controllers
    // If the same application uses Razor Pageg (In case of Identity)
    // then Globally applied FIlters will crash, better apply them
    // on COntrollers
   // options.Filters.Add(new LoggerFilterAttribute());
    // register the exception filter
    // AUto-REsolve the IMOdelMetadataProvider from MvcOptions 
   // options.Filters.Add(typeof(CustomExceptionFilter));
});

// 4. Add The Service REgistration for Accepting Requests for Razor Pages aka Identity Page
// Added in the Application
builder.Services.AddRazorPages();

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
// Add the Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();
// 5. The Request Processing for Razor View aka Identity RazorPages Added in the Application
app.MapRazorPages();


// ROute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
