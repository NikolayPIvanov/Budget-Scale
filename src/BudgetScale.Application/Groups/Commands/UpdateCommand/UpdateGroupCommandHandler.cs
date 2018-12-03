using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Application.Groups.Models.Input;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.UpdateCommand
{
    public class UpdateGroupCommandHandler : BaseEntity, IRequestHandler<UpdateGroupCommand, Unit>
    {
        public UpdateGroupCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}