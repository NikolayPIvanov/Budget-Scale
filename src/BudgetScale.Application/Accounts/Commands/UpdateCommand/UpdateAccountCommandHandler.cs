using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Accounts.Commands.UpdateCommand
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand,Unit>
    {
        public ApplicationDbContext Context { get; }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            Context.Accounts.Where(a => a.AccountId.Equals(request.AccountId)).Update(x => new Account()
            {
                ModifiedOn = DateTime.UtcNow,
                AccountName = request.AccountName,
                AccountType = (AccountType)Enum.Parse(typeof(AccountType), request.AccountType)
            });

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }   

        public UpdateAccountCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}