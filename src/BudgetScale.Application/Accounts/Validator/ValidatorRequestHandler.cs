using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Accounts.Validator
{
    public class ValidatorRequestHandler : BaseHandler, IRequestHandler<ValidatorRequest, (bool Exists, bool Authorized)>
    {
        public async Task<(bool Exists, bool Authorized)> Handle(ValidatorRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts
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

        public ValidatorRequestHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}