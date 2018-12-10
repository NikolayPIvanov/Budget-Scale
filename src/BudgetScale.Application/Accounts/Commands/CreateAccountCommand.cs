using MediatR;

namespace BudgetScale.Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<string>
    {

        public string UserId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
    }
}