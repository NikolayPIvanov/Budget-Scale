using System.Collections.Generic;
using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Accounts.Queries.GetAccounts
{
    public class GetAllAccountsQuery : IRequest<IQueryable<Account>>
    {
        public GetAllAccountsQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; set; }
    }
}