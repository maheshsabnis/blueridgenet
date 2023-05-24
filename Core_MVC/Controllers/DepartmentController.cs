using Microsoft.AspNetCore.Mvc;
using Core_MVC.Models;
using Core_MVC.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Core_MVC.CustomSessionExtensions;
using Core_MVC.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace Core_MVC.Controllers
{
    /// <summary>
    /// COntrller has Action Methods
    /// By DEfault each Action Method is of the type
    /// HttpGet, to perform Write Operations (POST, PUT, and DELETE)
    /// we have to apply HttpPost attribute on such action methods
    /// </summary>
    /// 
    /// Applying the Action Filter at controller Level
    //[LoggerFilter]
    //[Authorize]
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
        /// 
        //   [Authorize(Roles = "Manager, Clerk, Operator")]
        [Authorize(Policy = "ReadPolicy")]
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
        /// 
        //    [Authorize(Roles = "Manager, Clerk")]
        [Authorize(Policy = "CreatePolicy")]
        public IActionResult Create()
        {
            var dept = new Department();   
            // PAss an EMpty Department Object to View
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                if (dept.DeptName.StartsWith(' '))
                    throw new Exception("DeptName cannot starts from blanckspace");
                // check if Dept exist based on DeptNAme
                if (!CheckIdDepartmentNameExist(dept.DeptName))
                {
                    var result = deptServ.Create(dept);
                    // Redirect to an Index Action method
                    // that will show List of Departments
                    return RedirectToAction("Index");
                }
                //  ViewBag.ErrorMessage = $"DeptName {dept.DeptName} is already exist";
                ViewData["ErrorMessage"] = $"DeptName {dept.DeptName} is already exist";
                return View(dept);
                
            }
            // Stay on same page showing error messages
            return View(dept);
           
        }

        //   [Authorize(Roles = "Manager")]
        [Authorize(Policy = "EditDeletePolicy")]
        public IActionResult Edit(int id)
        {
            var response = deptServ.Get(id);
            return View(response.Record);
        }

        [HttpPost]
        public IActionResult Edit(int id , Department dept) 
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    if (dept.DeptName.StartsWith(' '))
                        throw new Exception("DeptName cannot starts from blanckspace");
                    var response = deptServ.Update(id, dept);
                    return RedirectToAction("Index");
                }
                // Stay on same page showing error messages
                return View(dept);
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new ErrorViewModel() 
            //    {
            //        //ControllerName = "Department",
            //        //ActionName = "Edit",
            //        //ErrorMEssage = ex.Message

            //        ControllerName = RouteData.Values["controller"].ToString(),
            //        ActionName = RouteData.Values["action"].ToString(),
            //        ErrorMEssage = ex.Message
            //    });
            //}
        }
        //  [Authorize(Roles = "Manager")]
        [Authorize(Policy = "EditDeletePolicy")]
        public IActionResult Delete(int id)
        {
            var response = deptServ.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ShowEmployees(int id)
        {
            // Set the id i.e. DeptNo in session object 
            this.HttpContext.Session.SetInt32("DeptNo", id);
            // USing TempData
            TempData["DeptNo"] = id;
            // Get the DEpartment Object
            var dept = deptServ.Get(id).Record;
            // Save the the dept in Session State
            HttpContext.Session.SetObject<Department>("Dept", dept);
            // REdirect to an Index Vew of an EMployeeController
            return RedirectToAction("Index", "Employee");
        }


        private bool CheckIdDepartmentNameExist(string dname)
        { 
            // Check for Department based on DeptName 
            var dept = deptServ.Get().Records.Where(d=>d.DeptName.Trim() == dname.Trim()).FirstOrDefault();
            if(dept != null) return true; // Exist
            return false; // Not exist
        }
    }
}
