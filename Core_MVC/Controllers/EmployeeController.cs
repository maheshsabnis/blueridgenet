using Microsoft.AspNetCore.Mvc;
using Core_MVC.Models;
using Core_MVC.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Core_MVC.CustomSessionExtensions;
namespace Core_MVC.Controllers
{
    /// <summary>
    /// COntrller has Action Methods
    /// By DEfault each Action Method is of the type
    /// HttpGet, to perform Write Operations (POST, PUT, and DELETE)
    /// we have to apply HttpPost attribute on such action methods
    /// </summary>
    public class EmployeeController : Controller
    {
        private readonly IServices<Employee, int> empServ;

        /// <summary>
        /// Inject the IService<Employee,int> as contructor injection
        /// so that EmployeeService instace will be injected to this controller
        /// provided EmployeeService is registered in DI Container as follows
        /// builder.Services.AddScopped<IServices<Dpartment,int>,EmployeeService>();
        /// </summary>
        public EmployeeController(IServices<Employee, int> empServ)
        {
            this.empServ = empServ;
        }

        /// <summary>
        /// Action Method that is supposed to show LIst of Employees
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            // REad DEptNO from the Session
            int DeptNo = Convert.ToInt32(HttpContext.Session.GetInt32("DeptNo"));

            // Red data from TempData
            int dno = Convert.ToInt32(TempData["DeptNo"]);


            // REad the Dept from Session State
            var dept = HttpContext.Session.GetObject<Department>("Dept");
            var records = empServ.Get().Records;
            if (DeptNo == 0)
            {
                // Read All EMployees
                employees = records;
            }
            else
            {
                // Ead EMployees based on DeptNo
                employees = records.Where(e => e.DeptNo == DeptNo).ToList();    
            }

            // Keep the Data in TemData, either store all keys or specific key
            // Note: Pass the KeyName to the Keep() method
            TempData.Keep();  
             
            // PAssing List of Depatments
            return View(employees);
        }
        /// <summary>
        ///HttpGet
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var dno = Convert.ToInt32(TempData["DeptNo"]); 
            var emp = new Employee();   
            // PAss an EMpty Employee Object to View
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                
                    var result = empServ.Create(emp);
                    // Redirect to an Index Action method
                    // that will show List of Employees
                    return RedirectToAction("Index");
                
                
                
            }
            // Stay on same page showing error messages
            return View(emp);
           
        }


        public IActionResult Edit(int id)
        {
            var dno = Convert.ToInt32(TempData["DeptNo"]);
            var response = empServ.Get(id);
            return View(response.Record);
        }

        [HttpPost]
        public IActionResult Edit(int id , Employee emp) 
        {
            
                if (ModelState.IsValid)
                {
                    
                    var response = empServ.Update(id, emp);
                    return RedirectToAction("Index");
                }
                // Stay on same page showing error messages
                return View(emp);
            
             
        }

        public IActionResult Delete(int id)
        {
            var response = empServ.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
