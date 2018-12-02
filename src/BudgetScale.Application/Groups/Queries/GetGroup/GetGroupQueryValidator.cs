using FluentValidation;

namespace BudgetScale.Application.Groups.Queries.GetGroup
{
    public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupQueryValidator()
        {
            RuleFor(e => e.Month).MinimumLength(3).MaximumLength(3).Matches("[A-Z]{1}[a-z]{2}").NotNull();
            RuleFor(e => e.GroupId).NotNull().NotEmpty();
            RuleFor(e => e.UserId).NotNull().NotEmpty();

        }
    }
}