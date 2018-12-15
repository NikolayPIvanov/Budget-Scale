using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransactionForAccountHandler : IRequestHandler<GetAllTransactionForAccount, IQueryable<Transaction>>
    {
        public ApplicationDbContext Context { get; }

        public async Task<IQueryable<Transaction>> Handle(GetAllTransactionForAccount request, CancellationToken cancellationToken)
        {
            return Context.Transactions
                .Where(e => e.SourceAccountId == request.AccountId && e.DestinationAccountId == request.AccountId)
                .AsQueryable();
        }

        public GetAllTransactionForAccountHandler(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}