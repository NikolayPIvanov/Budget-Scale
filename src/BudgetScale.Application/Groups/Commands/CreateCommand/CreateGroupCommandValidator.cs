using FluentValidation;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.GroupName).MinimumLength(3).MaximumLength(30).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
}