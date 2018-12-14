using System;
using BudgetScale.Domain.Entities;
using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace BudgetScale.Application.Accounts.Commands.UpdateCommand
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(e => e.AccountType).NotNull().Must(e =>
            {
                var isValid = Enum.TryParse(typeof(AccountType), e, out var result);

                return isValid;
            });

            RuleFor(e => e.AccountName).MaximumLength(20);
        }
    }
}