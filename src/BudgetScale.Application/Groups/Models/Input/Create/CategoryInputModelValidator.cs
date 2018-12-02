using FluentValidation;

namespace BudgetScale.Application.Groups.Models.Input.Create
{
    public class CategoryInputModelValidator : AbstractValidator<CommandInputModel>
    {
        public CategoryInputModelValidator()
        {
            RuleFor(x => x.GroupName).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}