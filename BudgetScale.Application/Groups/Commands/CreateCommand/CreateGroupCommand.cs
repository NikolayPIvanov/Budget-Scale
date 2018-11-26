using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<string>
    {
        public CreateGroupCommand()
        {
        }

        public string GroupName { get; set; }
        public ApplicationUser User { get; internal set; }
        public string UserId { get; internal set; }
    }
}