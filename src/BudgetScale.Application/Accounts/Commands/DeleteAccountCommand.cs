using MediatR;

namespace BudgetScale.Application.Accounts.Commands
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public string AccountId { get; set; }
    }
}