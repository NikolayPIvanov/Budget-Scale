using MediatR;

namespace BudgetScale.Application.Groups.Models.Input
{
    public class UpdateGroupCommand : IRequest<Unit>
    {
        public string  GroupId { get; set; }

        public string GroupName { get; set; }

    }
}