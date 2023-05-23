using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_App.MOdels;
namespace API_App.Controllers
{
    [Route("api/[controller]/[action]")]
   // [ApiController]
    public class BinderAPIController : ControllerBase
    {
        [HttpPost]
        [ActionName("PostBody")]
        public IActionResult PostFromBody([FromBody]Department dept)
        {
            return Ok();
        }

        /// <summary>
        /// https://localhost:7196/api/BinderAPI/PostQueryOld?DeptNo=10001&DeptName=Test&Location=Pune&Capacity=8888
        /// </summary>
        /// <param name="DeptNo"></param>
        /// <param name="DeptName"></param>
        /// <param name="Location"></param>
        /// <param name="Capacity"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostQueryOld")]
        public IActionResult PostFromQueryOld(int DeptNo, string DeptName, string Location, int Capacity)
        {
            Department department = new Department() 
            {
               DeptNo = DeptNo,
               Location = Location,
               Capacity = Capacity,
               DeptName = DeptName
            };
            return Ok();
        }

        [HttpPost]
        [ActionName("PostQuery")]
        public IActionResult PostFromQuery([FromQuery] Department dept)
        {
            return Ok();
        }

        /// <summary>
        /// https://localhost:7196/api/BinderAPI/PostRoute/10001/Test/Pune/8888
        /// 
        /// Parameter Name in URL Template MUST match with the Properties of CLR Object
        /// e.g. {DeptNo}/{DeptName}/{Location}/{Capacity} matches with Properties of Department Class
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost("{DeptNo}/{DeptName}/{Location}/{Capacity}")]
        [ActionName("PostRoute")]
        public IActionResult PostFromRoute([FromRoute] Department dept)
        {
            return Ok();
        }
    }
}
