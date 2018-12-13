using MediatR;

namespace BudgetScale.Application.Accounts.Commands.CreateCommand
{
    public class CreateAccountCommand : IRequest<string>
    {

        public string UserId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
    }
}