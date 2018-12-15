using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<Account>
    {
        public string AccountId { get; set; }
    }
}