using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IQueryable<Group>>
    {
        public ApplicationDbContext Context { get; }

        public GetGroupsQueryHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IQueryable<Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            Context.Filter<Group>(i => i.Where(g => g.UserId.Equals(request.UserId)));

            var groups = this.Context.Groups
                .Include(g => g.Categories);

            foreach (var @group in groups)
            {
                @group.Categories = @group.Categories.Where(g => g.Month.Equals(request.Month)).ToList();
            }
                
            return groups;

        }


    }
}