using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Transactions.Query.TransactionsForUser
{
    public class GetTransactionsForUserQuery : IRequest<IQueryable<Transaction>>
    {
        public string UserId { get; set; }

    }
}