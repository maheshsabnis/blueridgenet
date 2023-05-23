using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Core_MVC.CustomFilters
{
    public class LoggerFilterAttribute : ActionFilterAttribute
    {
        private void LogRequest(string currentStatus, RouteData route)
        {
            string controller = route.Values["controller"].ToString();
            string action = route.Values["action"].ToString();

            Debug.WriteLine($"Current STatus of Execution is {currentStatus} in action {action} method of  {controller} COntroller ");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LogRequest("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LogRequest("OnActionExecuted", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            LogRequest("OnResultExecuting", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            LogRequest("OnResultExecuted", context.RouteData);
        }
    }
}
