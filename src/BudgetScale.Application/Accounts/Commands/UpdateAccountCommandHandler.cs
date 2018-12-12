using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Accounts.Commands
{
    public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts
                .FirstOrDefaultAsync(e => e.AccountId == request.AccountId, cancellationToken: cancellationToken);

            entity.ModifiedOn = DateTime.UtcNow;
            entity.AccountName = request.AccountName;
            entity.AccountType = (AccountType) Enum.Parse(typeof(AccountType), request.AccountType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public UpdateAccountCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}