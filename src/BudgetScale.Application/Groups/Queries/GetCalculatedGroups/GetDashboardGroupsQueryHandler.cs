using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Groups.Queries.GetCalculatedGroups
{
    public class GetDashboardGroupsQueryHandler : BaseHandler,
        IRequestHandler<GetDashboardGroupsQuery, IEnumerable<GroupDashboardViewModel>>
    {
        public GetDashboardGroupsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<GroupDashboardViewModel>> Handle(GetDashboardGroupsQuery request, CancellationToken cancellationToken)
        {
            var model = _context.Groups
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