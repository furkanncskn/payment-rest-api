using FluentValidation;
using Tringle.Core.DTOs;

namespace Tringle.Service.Validations.FluentValidation
{
    public class PostAccountDtoValidator : AbstractValidator<PostAccountDto>
    {
        public PostAccountDtoValidator()
        {
            RuleFor(p => p.AccountNumber)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .GreaterThan(0)
                .WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");

            RuleFor(p => p.OwnerName)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' is required")
                .MinimumLength(1)
                .WithMessage(
                    "'{PropertyName}' must be at least {MinLength} characters."
                );

            RuleFor(p => p.AccountType)
                 .NotEmpty()
                 .WithMessage("'{PropertyName}' is required")
                 .NotNull()
                 .WithMessage("'{PropertyName}', '{PropertValue}' is invalid");

            RuleFor(p => p.CurrencyCode)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .NotNull()
                .WithMessage("'{PropertyName}', '{PropertValue}' is invalid");
        }
    }
}
