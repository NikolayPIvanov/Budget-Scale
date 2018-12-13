using MediatR;

namespace BudgetScale.Application.Accounts.Commands.UpdateCommand
{
    public class UpdateAccountCommand : IRequest<Unit>
    {
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountType { get; set; }
    }
}