using MediatR;

namespace BudgetScale.Application.Accounts.Commands.DeleteCommand
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public string AccountId { get; set; }
    }
}