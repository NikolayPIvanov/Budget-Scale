﻿using System.Linq;
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
            return await _context.Accounts
                .Where(a => a.UserId.Equals(request.UserId))
                .FirstOrDefaultAsync(a => a.AccountId.Equals(request.AccountId), cancellationToken: cancellationToken);
        }
    }
}