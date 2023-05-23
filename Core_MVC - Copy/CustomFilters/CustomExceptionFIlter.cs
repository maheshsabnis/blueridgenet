using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Core_MVC.CustomFilters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// THis will be resolved by MvcOptions
        /// </summary>
        private readonly IModelMetadataProvider modelMetadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }

        /// <summary>
        /// ExceptionContext: Handles the Exception and read it 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            // Handle the execption same as 'catch' block
             context.ExceptionHandled = true;
            // Read teh exception Message
            string message = context.Exception.Message;

            // define a ViewResult to Move to the Error View

            ViewResult viewResult = new ViewResult();

            // Since the ViewResult has the 'Model' as Readonly property
            // to pass Exception MEssage, COntrollerNAme, ActionNae, etc data to it
            // we need to use ViewData of the type ViewDataDictionary 
            // MOdelState is received from the BAse class of ExceptionContext
            ViewDataDictionary viewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);
            // Define keys for ViewData
            viewData["controller"] = context.RouteData.Values["controller"].ToString();
            viewData["action"] = context.RouteData.Values["action"].ToString();
            viewData["message"] = message;
            // Pass viewData to VeiwData dictionary of ViewResult
            viewResult.ViewData = viewData;
            // Set the ViewNAme
            viewResult.ViewName = "Error"; // The Error Page
            // Now set the result
            context.Result = viewResult;

        }
    }
}
