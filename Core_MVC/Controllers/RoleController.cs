using Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> role,UserManager<IdentityUser> user)
        {
                roleManager = role;
            userManager = user;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        { 
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public IActionResult AssignRoleToUser()
        {
            var userRoles = new UserRoles()
            {
                //Roles = roleManager.Roles.ToList(),
                //Users = userManager.Users.ToList(),
                UserEmail = string.Empty   ,
                RoleName = string.Empty 
            };

            List<SelectListItem> listRole = new List<SelectListItem>();
            listRole.Add(new SelectListItem() { Text="Select Role",Value="Select Role"});
            foreach (var role in roleManager.Roles.ToList()) 
            {
                listRole.Add(new SelectListItem() { Text = role.Name, Value = role.Name });
            }

            List<SelectListItem> listUsers = new List<SelectListItem>();
            listUsers.Add(new SelectListItem() { Text = "Select User", Value = "Select User" });
            foreach (var user in userManager.Users.ToList())
            {
                listUsers.Add(new SelectListItem() { Text = user.Email, Value = user.Email });
            }
            // Save USers and Roles in Model that is passed to View
            userRoles.Roles = listRole;
            userRoles.Users = listUsers;

            return View(userRoles);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(UserRoles userRoles)
        {

            // Logic to Assign Role to User
            // 1. CReate an Instance of IdenttyUser based on EMail
            IdentityUser? user = new IdentityUser();
            user = await userManager.FindByEmailAsync(userRoles.UserEmail);
            await userManager.AddToRoleAsync(user, userRoles.RoleName);


            List<SelectListItem> listRole = new List<SelectListItem>();
            listRole.Add(new SelectListItem() { Text = "Select Role", Value = "Select Role" });
            foreach (var role in roleManager.Roles.ToList())
            {
                listRole.Add(new SelectListItem() { Text = role.Name, Value = role.Name });
            }

            List<SelectListItem> listUsers = new List<SelectListItem>();
            listUsers.Add(new SelectListItem() { Text = "Select User", Value = "Select User" });
            foreach (var user1 in userManager.Users.ToList())
            {
                listUsers.Add(new SelectListItem() { Text = user1.Email, Value = user1.Email });
            }
            // Save USers and Roles in Model that is passed to View
            userRoles.Roles = listRole;
            userRoles.Users = listUsers;
            return View(userRoles);
        }
    }
}
