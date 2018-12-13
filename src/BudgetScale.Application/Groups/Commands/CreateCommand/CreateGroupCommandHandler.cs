using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommandHandler : BaseHandler, IRequestHandler<CreateGroupCommand, string>
    {
        public CreateGroupCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<string> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(request);

            group.User = await this.Context.Users.FindAsync(request.UserId);

            this.Context.Add(group);

            await this.Context.SaveChangesAsync(cancellationToken);

            return group.GroupId;
        }


    }
}