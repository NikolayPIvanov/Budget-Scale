using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransactionForAccount : IRequest<IQueryable<Transaction>>
    {
        public string AccountId { get; set; }   
    }
}