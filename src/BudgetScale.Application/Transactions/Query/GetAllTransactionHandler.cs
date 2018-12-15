using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransactionHandler : IRequestHandler<GetAllTransaction,IQueryable<Transaction>>
    {
        public ApplicationDbContext Context { get; }

        public GetAllTransactionHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IQueryable<Transaction>> Handle(GetAllTransaction request, CancellationToken cancellationToken)
        {
            return Context.Transactions.AsQueryable();
        }
    }
}