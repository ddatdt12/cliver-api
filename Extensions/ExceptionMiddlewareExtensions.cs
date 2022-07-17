using CliverApi.Error;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CliverApi.Extensions
{
  public static class ExceptionMiddlewareExtensions
  {
    public static void ConfigureExceptionHandler(this IApplicationBuilder app,
   ILogger logger)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
                  {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                      logger.LogError($"Something went wrong: {contextFeature.Error}");

                      var errorDetail = contextFeature.Error as HttpResponseException;
                      if (errorDetail != null)
                      {
                        context.Response.StatusCode = errorDetail.StatusCode;
                      }
                      await context.Response.WriteAsync(
                        new HttpResponseException(contextFeature.Error.Message ?? "Internal Server Error.")
                        {
                          StatusCode = context.Response.StatusCode
                        }
                      .ToString());
                    }
                  });
      });
    }

  }
}
