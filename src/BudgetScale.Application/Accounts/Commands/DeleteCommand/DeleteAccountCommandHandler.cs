using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Accounts.Commands.DeleteCommand
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand,Unit>
    {
        public ApplicationDbContext Context { get; }

        public DeleteAccountCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            
            Context.Accounts.Where(e => e.AccountId == request.AccountId).Delete();

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}