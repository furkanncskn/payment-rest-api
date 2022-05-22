using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tringle.Core.DTOs.ResponseDtos;

namespace Tringle.API.Filters
{
    public class AsyncValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(NoContentResponseDto.Fail(400, errors));
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
