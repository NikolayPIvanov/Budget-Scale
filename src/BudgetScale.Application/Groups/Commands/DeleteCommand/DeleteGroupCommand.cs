using MediatR;

namespace BudgetScale.Application.Groups.Commands.DeleteCommand
{
    public class DeleteGroupCommand : IRequest<Unit>
    {
        public string GroupId { get; set; }
    }
}