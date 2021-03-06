using FluentValidation;
using Tringle.Core.DTOs;

namespace Tringle.Service.Validations.FluentValidation
{
    public class DepositOrWithdrawDtoValidator : AbstractValidator<DepositOrWithdrawDto>
    {
        public DepositOrWithdrawDtoValidator()
        {
            RuleFor(p => p.AccountNumber)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .GreaterThan(0)
                .WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");

            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("'{PropertyName}' is required")
                .GreaterThan(0)
                .WithMessage("'{PropertyName}' must be greater than {ComparisonValue}")
                .ScalePrecision(2, 10)
                .WithMessage("'{PropertyName}' must not be more than {ExpectedScale} digits in total, with allowance for {ExpectedPrecision} decimals.");
        }
    }
}
