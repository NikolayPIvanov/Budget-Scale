using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Transactions.Query.TransactionsForUser
{
    public class GetTransactionsForUserQueryHandler : IRequestHandler<GetTransactionsForUserQuery, IQueryable<Transaction>>
    {
        private readonly ApplicationDbContext _context;

        public GetTransactionsForUserQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Transaction>> Handle(GetTransactionsForUserQuery request, CancellationToken cancellationToken)
        {
            return _context.Transactions
                .Include(t => t.DestinationAccount)
                .Include(t => t.SourceAccount)
                .Where(t => t.SourceAccount.UserId.Equals(request.UserId) ||
                            t.DestinationAccount.UserId.Equals(request.UserId));
        }
    }
}