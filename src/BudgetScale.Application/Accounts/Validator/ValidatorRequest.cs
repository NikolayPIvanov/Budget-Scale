using MediatR;

namespace BudgetScale.Application.Accounts.Validator
{
    public class ValidatorRequest : IRequest<(bool Exists, bool Authorized)>
    {
        public string AccountId { get; set; }

        public string UserId { get; set; }
    }
}