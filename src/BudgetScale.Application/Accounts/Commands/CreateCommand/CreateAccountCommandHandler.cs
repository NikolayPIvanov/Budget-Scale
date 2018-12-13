using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Accounts.Commands.CreateCommand
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
    {
        public ApplicationDbContext Context { get; }
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Account>(request);

            entity.ApplicationUser = await Context.Users.FindAsync(request.UserId);

            Context.Accounts.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.AccountId;

        }
    }
}