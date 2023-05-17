using Microsoft.AspNetCore.Mvc;

namespace Core_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
