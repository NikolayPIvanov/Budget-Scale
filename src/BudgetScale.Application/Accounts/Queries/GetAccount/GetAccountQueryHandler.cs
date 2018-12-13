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
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, Account>
    {
        private readonly ApplicationDbContext _context;

        public GetAccountQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var s =  await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId.Equals(request.AccountId), cancellationToken: cancellationToken);

            return s;
        }
    }
}