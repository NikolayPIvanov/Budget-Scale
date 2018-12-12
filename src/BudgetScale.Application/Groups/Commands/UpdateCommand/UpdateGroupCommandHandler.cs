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
    public class UpdateGroupCommandHandler : BaseHandler, IRequestHandler<UpdateGroupCommand, Unit>
    {
        public UpdateGroupCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            await _context.Groups.Where(g => g.GroupId.Equals(request.GroupId))
                .UpdateAsync(x => new Group {GroupName = request.GroupName}, cancellationToken);

            return Unit.Value;
        }
    }
}