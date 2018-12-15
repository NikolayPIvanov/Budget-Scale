using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Groups.Queries.GetCalculatedGroups
{
    public class GetDashboardGroupsQueryHandler :
        IRequestHandler<GetDashboardGroupsQuery, IEnumerable<GroupDashboardViewModel>>
    {
        public ApplicationDbContext Context { get; }

        public GetDashboardGroupsQueryHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<GroupDashboardViewModel>> Handle(GetDashboardGroupsQuery request, CancellationToken cancellationToken)
        {
            var model = Context.Groups
                .Include(g => g.Categories)
                .Where(g => g.UserId.Equals(request.UserId))
                .Select(g => new GroupDashboardViewModel
                {
                    Budgeted = g.Categories.Sum(e => e.Budgeted),
                    Activity = g.Categories.Sum(e => e.Activity),
                    Availability = g.Categories.Sum(e => e.Available),
                    GroupId = g.GroupId,
                    GroupName = g.GroupName,
                    Categories = g.Categories.Select(e => new CategoryViewModel
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName,
                    })
                });

            return model;
        }
    }
}