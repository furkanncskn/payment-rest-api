using FluentValidation;
using Tringle.Core.DTOs;

namespace Tringle.Service.Validations.FluentValidation
{

    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
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

            RuleFor(p => p.Balance)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .GreaterThan(0)
                .WithMessage("'{PropertyName}' must be greater than {ComparisonValue}")
                .ScalePrecision(2, 10)
                .WithMessage("'{PropertyName}' must not be more than {ExpectedScale} digits in total, with allowance for {ExpectedPrecision} decimals.");

            RuleFor(p => p.CurrencyCode)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .NotNull()
                .WithMessage("'{PropertyName}', '{PropertValue}' is invalid");

            RuleFor(p => p.AccountType)
                 .NotEmpty()
                 .WithMessage("'{PropertyName}' is required")
                 .NotNull()
                 .WithMessage("'{PropertyName}', '{PropertValue}' is invalid");
        }
    }

}
