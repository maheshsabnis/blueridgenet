using Microsoft.AspNetCore.Mvc;
using Core_MVC.Models;
using Core_MVC.Services;

namespace Core_MVC.Controllers
{
    /// <summary>
    /// COntrller has Action Methods
    /// By DEfault each Action Method is of the type
    /// HttpGet, to perform Write Operations (POST, PUT, and DELETE)
    /// we have to apply HttpPost attribute on such action methods
    /// </summary>
    public class DepartmentController : Controller
    {
        private readonly IServices<Department, int> deptServ;

        /// <summary>
        /// Inject the IService<Department,int> as contructor injection
        /// so that DepartmentService instace will be injected to this controller
        /// provided DepartmentService is registered in DI Container as follows
        /// builder.Services.AddScopped<IServices<Dpartment,int>,DepartmentService>();
        /// </summary>
        public DepartmentController(IServices<Department, int> deptServ)
        {
            this.deptServ = deptServ;
        }

        /// <summary>
        /// Action Method that is supposed to show LIst of Departments
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = deptServ.Get();
            // PAssing List of Depatments
            return View(result.Records);
        }
        /// <summary>
        ///HttpGet
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var dept = new Department();   
            // PAss an EMpty Department Object to View
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        { 
            var result = deptServ.Create(dept);
            // Redirect to an Index Action method
            // that will show List of Departments
            return RedirectToAction("Index");
        }
    }
}
