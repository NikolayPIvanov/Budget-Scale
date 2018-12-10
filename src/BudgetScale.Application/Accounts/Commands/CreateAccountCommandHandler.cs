using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Accounts.Commands
{
    public class CreateAccountCommandHandler : BaseHandler, IRequestHandler<CreateAccountCommand, string>
    {
        public CreateAccountCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Account>(request);

            entity.ApplicationUser = await _context.Users.FindAsync(request.UserId);

            _context.Accounts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.AccountId;

        }
    }
}