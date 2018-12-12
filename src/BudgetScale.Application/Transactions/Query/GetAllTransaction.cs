using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransaction : IRequest<IQueryable<Transaction>>
    {
        
    }
}