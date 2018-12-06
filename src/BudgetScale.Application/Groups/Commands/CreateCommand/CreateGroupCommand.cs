
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<Group>
    {   
        public string UserId { get; set; }
        public string GroupName { get; set; }
    }
}   