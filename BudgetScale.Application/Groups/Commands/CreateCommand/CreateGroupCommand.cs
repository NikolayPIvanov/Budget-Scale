
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<string>
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }
    }
}