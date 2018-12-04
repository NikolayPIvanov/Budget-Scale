using FluentValidation;

namespace BudgetScale.Application.Accounts.Queries.GetAccounts
{
    public class GetAllAccountsQueryValidator : AbstractValidator<GetAllAccountsQuery>
    {
        public GetAllAccountsQueryValidator()
        {
            RuleFor(e => e.UserId).NotNull().NotEmpty();
        }
    }
}