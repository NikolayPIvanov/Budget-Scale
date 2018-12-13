using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Requests.Queries.AllRequests
{
    public class AllRequestsHandler : IRequestHandler<AllRequests, IQueryable<LongRequest>>
    {
        public ApplicationDbContext Context { get; }

        public async Task<IQueryable<LongRequest>> Handle(AllRequests request, CancellationToken cancellationToken)
        {
            //TODO : Check again
            return Context.LongRequests
                .Where(lr => DateTime.UtcNow.AddHours(-request.Hours) <= lr.Time)
                .OrderByDescending(lr => lr.Time);
        }

        public AllRequestsHandler(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}