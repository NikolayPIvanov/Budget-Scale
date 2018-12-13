using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Accounts.Queries.GetAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IQueryable<Account>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAccountsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return _context.Accounts
                .Include(a => a.Transactions)
                .Where(a => a.UserId.Equals(request.UserId));
        }

        
    }
}