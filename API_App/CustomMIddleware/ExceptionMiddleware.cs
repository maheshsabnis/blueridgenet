namespace API_App.CustomMIddleware
{
    public class ErrorDetails
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
    /// <summary>
    /// Middleware Logic Class
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _requestDelegate = request;
        }

        /// <summary>
        /// Logic Method
        /// THis will be Auto-Invoked using RequestDelegate
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // If no error then move to next middlewarein HTTP PIpeline
                await _requestDelegate(ctx);
            }
            catch (Exception ex)
            {
                 //else Hadle Exception and Generate Response
                 // Set the Error COde and ErrorMessage
                 ctx.Response.StatusCode = 500;
                 string message = ex.Message;

                // save this data in ErrorDetails
                var errorDetails = new ErrorDetails()
                {
                     ErrorCode = ctx.Response.StatusCode,
                     ErrorMessage = message
                };

                // Generate Response by JSON Serialzation

                await ctx.Response.WriteAsJsonAsync(errorDetails);
            }
        }
        
    }

    /// <summary>
    /// Class that will register the ExceptionMiddleware class
    /// Custom Middleware in HTTP ipeline
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static void GlobalErrorHandler(this IApplicationBuilder app)
        {
            // REgister ExceptionMiddleware class as Custom middeware
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
