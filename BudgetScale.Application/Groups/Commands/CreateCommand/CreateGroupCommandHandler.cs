using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Commands.CreateCommand
{
    public class CreateGroupCommandHandler : BaseEntity, IRequestHandler<CreateGroupCommand, string>
    {
        public CreateGroupCommandHandler(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                GroupName = request.GroupName,
                User = await this._context.Users.FindAsync(request.UserId),
                UserId = request.UserId
            };

            this._context.Add(entity);

            await this._context.SaveChangesAsync(cancellationToken);

            return entity.GroupId;
        }

        
    }
}