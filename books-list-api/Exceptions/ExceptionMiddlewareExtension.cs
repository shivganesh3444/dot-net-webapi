using Azure.Core;
using books_list_api.Data.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace books_list_api.Exceptions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureBuildInMiddlewareException(this IApplicationBuilder app) {
            //here UseExceptionHandler is built in middleware used to handle exception
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    //get the original error using http context feature and Exception handler feature
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //get the original path from where exception occurs
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if(contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorVM()
                        {
                            StatusCode = context.Response.StatusCode,
                            ErrorMessage = contextFeature.Error.Message,
                            Path = contextRequest.Path
                        }.ToString());
                    }

                });
            });   
        }
    }
}
