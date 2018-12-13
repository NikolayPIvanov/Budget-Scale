using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Application.Groups.Models.Input;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Groups.Commands.UpdateCommand
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        public ApplicationDbContext Context { get; }

        public UpdateGroupCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            await Context.Groups.Where(g => g.GroupId.Equals(request.GroupId))
                .UpdateAsync(x => new Group {GroupName = request.GroupName}, cancellationToken);

            return Unit.Value;
        }
    }
}