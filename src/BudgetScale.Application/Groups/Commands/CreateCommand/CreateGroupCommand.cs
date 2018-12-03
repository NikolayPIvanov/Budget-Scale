
using System.Threading.Tasks;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<string>
    {   
        public string UserId { get; set; }
        public string GroupName { get; set; }
    }
}   