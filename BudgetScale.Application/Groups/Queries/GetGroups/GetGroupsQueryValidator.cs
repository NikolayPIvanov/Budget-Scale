using FluentValidation;

namespace BudgetScale.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQueryValidator : AbstractValidator<GetGroupsQuery>
    {
        public GetGroupsQueryValidator()
        {

            RuleFor(e => e.Month).MinimumLength(3).MaximumLength(3).Matches("[A-Z]{1}[a-z]{2}").NotNull();
            RuleFor(e => e.UserId).NotNull();
        }
    }
}