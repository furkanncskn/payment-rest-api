using Microsoft.AspNetCore.Diagnostics;
using Tringle.Core.ResponseDtos;
using Tringle.Service.Exceptions;

namespace Tringle.API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(option => option.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                context.Response.StatusCode = exceptionFeature?.Error switch
                {
                    ClientSideException => 400,
                    UnauthorizedException => 401,
                    ForbidException => 403,
                    NotFoundException => 404,
                    _ => 500,
                };

                var response = new ErrorDetailDto()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exceptionFeature?.Error.Message,
                };

                await context.Response.WriteAsJsonAsync(response);
            }));
        }
    }
}
