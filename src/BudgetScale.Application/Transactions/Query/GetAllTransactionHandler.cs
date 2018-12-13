using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Transactions.Query
{
    public class GetAllTransactionHandler : BaseHandler, IRequestHandler<GetAllTransaction,IQueryable<Transaction>>
    {
        public GetAllTransactionHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IQueryable<Transaction>> Handle(GetAllTransaction request, CancellationToken cancellationToken)
        {
            return Context.Transactions.AsQueryable();
        }
    }
}