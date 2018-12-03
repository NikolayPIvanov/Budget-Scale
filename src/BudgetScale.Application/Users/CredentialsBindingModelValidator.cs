using FluentValidation;

namespace BudgetScale.Application.Users
{
    public class CredentialsBindingModelValidator : AbstractValidator<CredentialsBindingModel>
    {
        public CredentialsBindingModelValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.Password).Length(6, 32);
        }
    }
}