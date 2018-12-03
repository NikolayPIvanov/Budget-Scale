
using System.Threading.Tasks;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommand : IRequest<string>
    {
        public string GroupId { get; set; }
        public string UserId { get; set; }
        public string CategoryName { get; set; }
    }
}   