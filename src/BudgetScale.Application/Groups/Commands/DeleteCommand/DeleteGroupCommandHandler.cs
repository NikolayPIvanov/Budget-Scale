using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Groups.Commands.DeleteCommand
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand,Unit>
    {
        public ApplicationDbContext Context { get; }

        public DeleteGroupCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            //TODO: Not sure about first line of code. Note; research about the EF Core Plus 

            await Context.Categories.Where(c => c.GroupId.Equals(request.GroupId)).DeleteAsync(cancellationToken);
            await Context.Groups.Where(e => e.GroupId.Equals(request.GroupId)).DeleteAsync(x => x.BatchSize = 1,cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}