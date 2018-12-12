using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Accounts.Commands
{
    public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            _context.Accounts.Where(a => a.AccountId.Equals(request.AccountId)).Update(x => new Account()
            {
                ModifiedOn = DateTime.UtcNow,
                AccountName = request.AccountName,
                AccountType = (AccountType)Enum.Parse(typeof(AccountType), request.AccountType)
            });

            //entity.ModifiedOn = DateTime.UtcNow;
            //entity.AccountName = request.AccountName;
            //entity.AccountType = (AccountType)Enum.Parse(typeof(AccountType), request.AccountType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public UpdateAccountCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}