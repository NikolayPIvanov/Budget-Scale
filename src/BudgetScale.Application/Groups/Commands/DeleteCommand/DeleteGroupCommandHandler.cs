using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Groups.Commands.DeleteCommand
{
    public class DeleteGroupCommandHandler : BaseHandler,IRequestHandler<DeleteGroupCommand,Unit>
    {
        public DeleteGroupCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            //TODO: Not sure about first line of code. Note; research about the EF Core Plus 
            await _context.Categories.Where(c => c.GroupId.Equals(request.GroupId)).DeleteAsync(cancellationToken);
            await _context.Groups.Where(e => e.GroupId.Equals(request.GroupId)).DeleteAsync(x => x.BatchSize = 1,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}