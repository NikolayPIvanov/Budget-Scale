using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommandHandler : BaseEntity, IRequestHandler<CreateGroupCommand, string>
    {
        public CreateGroupCommandHandler(ApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }

        public async Task<string> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(request);

            group.User = await this._context.Users.FindAsync(request.UserId);

            this._context.Add(group);

            await this._context.SaveChangesAsync(cancellationToken);

            return group.GroupId;
        }

        
    }
}