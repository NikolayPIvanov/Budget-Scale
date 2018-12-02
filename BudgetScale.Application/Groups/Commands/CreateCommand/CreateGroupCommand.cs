using BudgetScale.Domain.Entities;
using BudgetScale.Infrastructure.Mapping;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<string>, IMapTo<Group>
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }
    }
}