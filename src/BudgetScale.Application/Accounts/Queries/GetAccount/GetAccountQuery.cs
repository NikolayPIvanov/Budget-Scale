using System.Collections.Generic;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<Account>
    {
        public string UserId { get; set; }

        public string AccountId { get; set; }
    }
}