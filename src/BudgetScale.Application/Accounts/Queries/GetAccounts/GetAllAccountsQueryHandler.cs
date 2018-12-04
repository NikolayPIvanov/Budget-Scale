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
    public class GetAllAccountsQueryHandler : BaseHandler, IRequestHandler<GetAllAccountsQuery, IQueryable<Account>>
    {
        public GetAllAccountsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IQueryable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return _context.Accounts
                .Include(a => a.Transactions);
        }

        
    }
}