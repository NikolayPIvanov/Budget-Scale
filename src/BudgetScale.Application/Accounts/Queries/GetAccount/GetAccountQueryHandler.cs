using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Accounts.Queries.GetAccount
{
    public class GetAccountQueryHandler : BaseHandler, IRequestHandler<GetAccountQuery, Account>
    {
        public GetAccountQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var s =  await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId.Equals(request.AccountId), cancellationToken: cancellationToken);

            return s;
        }
    }
}