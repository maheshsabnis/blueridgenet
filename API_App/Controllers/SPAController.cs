using Microsoft.AspNetCore.Mvc;

namespace API_App.Controllers
{
    public class SPAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePartial()
        {
            return PartialView("CreatePartial");
        }
        public IActionResult ListPartial()
        {
            return PartialView("ListPartial");
        }
        public IActionResult EditPartial()
        {
            return PartialView("EditPartial");
        }
        public IActionResult DeletePartial()
        {
            return PartialView("DeletePartial");
        }

    }
}
