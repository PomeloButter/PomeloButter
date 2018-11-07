using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PomeloApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public  static class ExceptionHandlingExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public static void UseApiExceptionHandler(this IApplicationBuilder app,ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(bulider =>
            {
                bulider.Run(async option =>
                {
                    option.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    option.Response.ContentType = "application/json";
                    var exception = option.Features.Get<IExceptionHandlerFeature>();
                    if (exception!=null)
                    {
                        var logger = loggerFactory.CreateLogger("PomeloApi.Extensions.ExceptionHandlingExtensions");
                        logger.LogError(500,exception.Error,exception.Error.Message);
                    }

                    await option.Response.WriteAsync(exception?.Error?.Message ?? "An Error Occurred");
                });
            });
        }
    }
}