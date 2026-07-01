using Microsoft.Extensions.Logging;
using System.Net;

namespace NZWalksAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public ILogger<ExceptionHandlerMiddleware> Logger { get; }
        public RequestDelegate Next { get; }

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            Logger = logger;
            Next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try{
                await Next(httpContext);
            }
            catch (Exception ex) {

                var errorId = new Guid();
                Logger.LogError("Something Went Wrong");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    message = ex.ToString()
                };

                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }

    }
}
