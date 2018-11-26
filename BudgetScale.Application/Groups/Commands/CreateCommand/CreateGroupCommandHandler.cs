using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, string>
    {
        private readonly ApplicationDbContext context;

        public CreateGroupCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                GroupName = request.GroupName,
                User = await this.context.Users.FindAsync(request.UserId),
                UserId = request.UserId
            };

            this.context.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return entity.GroupId;
        }
    }
}