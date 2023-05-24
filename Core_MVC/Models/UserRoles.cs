using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC.Models
{
    public class UserRoles
    {
        public string? UserEmail { get; set; } // USer NAme
        public string? RoleName { get; set; } // Role NAme
        public List<SelectListItem>? Users { get; set; }
        public List<SelectListItem>? Roles { get; set; }
    }
}
