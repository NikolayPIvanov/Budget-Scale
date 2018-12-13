using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Accounts.Validator
{
    public class ValidatorRequestHandler : IRequestHandler<ValidatorRequest, (bool Exists, bool Authorized)>
    {
        public ApplicationDbContext Context { get; }

        public async Task<(bool Exists, bool Authorized)> Handle(ValidatorRequest request, CancellationToken cancellationToken)
        {
            var entity = await Context.Accounts
                .FirstOrDefaultAsync(e => e.AccountId.Equals(request.AccountId), cancellationToken: cancellationToken);

            if (entity == null)
            {
                return (false, false);
            }

            if (entity.UserId != request.UserId)
            {
                return (true, false);
            }

            return (true,true);
        }

        public ValidatorRequestHandler(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}