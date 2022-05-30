using FluentValidation.AspNetCore;
using System.Reflection;
using Tringle.Service.Validations.FluentValidation;

namespace Tringle.API.Extensions
{
    public static class FluentValidationMiddlewareExtension
    {
        public static void ConfigureFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblies
                (
                    new List<Assembly>
                    {
                    Assembly.GetAssembly(typeof(AccountDtoValidator))!,
                    Assembly.GetAssembly(typeof(DepositOrWithdrawDtoValidator))!,
                    Assembly.GetAssembly(typeof(PaymentDtoValidator))!,
                    Assembly.GetAssembly(typeof(PostAccountDtoValidator))!,
                    }
                );

                config.ValidatorOptions.DefaultClassLevelCascadeMode = FluentValidation.CascadeMode.Continue;
                config.ValidatorOptions.DefaultRuleLevelCascadeMode = FluentValidation.CascadeMode.Stop;
                config.DisableDataAnnotationsValidation = true;
            }).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
        }
    }
}