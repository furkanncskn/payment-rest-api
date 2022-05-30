using Microsoft.AspNetCore.Mvc;
using Tringle.API.Filters;

namespace Tringle.API.Extensions
{
    public static class FilterMiddlewareExtension
    {
        public static void ConfigureFilter(this MvcOptions options)
        {
            options.Filters.Add(typeof(AsyncValidationFilter));
        }
    }
}
