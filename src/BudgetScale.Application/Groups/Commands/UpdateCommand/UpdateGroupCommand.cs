using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Models.Input
{
    public class UpdateGroupCommand : IRequest<Unit>
    {
        public Group Group { get; set; }

    }
}