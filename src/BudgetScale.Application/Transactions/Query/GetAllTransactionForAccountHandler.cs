using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransactionForAccountHandler : BaseHandler, IRequestHandler<GetAllTransactionForAccount, IQueryable<Transaction>>
    {
        public async Task<IQueryable<Transaction>> Handle(GetAllTransactionForAccount request, CancellationToken cancellationToken)
        {
            return _context.Transactions
                .Where(e => e.SourceAccountId == request.AccountId && e.DestinationAccountId == request.AccountId)
                .AsQueryable();
        }

        public GetAllTransactionForAccountHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}