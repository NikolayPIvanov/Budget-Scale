using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Accounts.Commands
{
    public class DeleteAccountCommandHandler : BaseHandler,IRequestHandler<DeleteAccountCommand,Unit>
    {
        public DeleteAccountCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            
            _context.Accounts.Where(e => e.AccountId == request.AccountId).Delete();

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}