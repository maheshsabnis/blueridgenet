using API_App.MOdels;
using API_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_App.Controllers
{
    /// <summary>
    /// ControllerBase: Methods for 
    /// 1. Response e.g. Ok(), NotFOund(), Conflict(), BadRequest(), etc
    /// 2. ModelState
    /// 
    /// ApiControllerAttribute class: USed to Map the Data from HTTP POST / PUT REquest Body to CLR Object
    /// in our case it is Department 
    /// Attrobutes for Http Methods
    /// [HttpGet], [HttpPost], [HttpPut], and [HttpDelete]
    /// </summary>
    [Route("api/[controller]")]
  [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        IService<Department, int> deptServ;

        public DepartmentAPIController(IService<Department, int> deptServ)
        {
                this.deptServ = deptServ;
        }
        /// <summary>
        /// https://localhost:[PORT]/api/Department
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var response = await deptServ.GetAsync();
            return Ok(response);
        }
        /// i<summary>
        /// The Route with 'id' in it
        /// https://localhost:[PORT]/api/Department/{id}
        /// Value of 'id' parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await deptServ.GetAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Department dept)
        {
            if (ModelState.IsValid)
            {
                var response = await deptServ.CreateAsync(dept);
                return Ok(response);
            }
            return BadRequest(dept);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Department dept)
        {
            if (ModelState.IsValid)
            {
                var response = await deptServ.UpdateAsync(dept);
                return Ok(response);
            }
            return BadRequest(dept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
                var response = await deptServ.DeleteAsync(id);
                return Ok(response);
           
        }

    }
}
