using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.CategoryInformation.Models.Output;
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
                .ThenInclude(c => c.CategoryInformation)
                .Where(g => g.UserId.Equals(request.UserId))
                .Select(g => new GroupDashboardViewModel
                {
                    Budgeted = g.Categories.Select(e => e.CategoryInformation.Select(p => p.Budgeted))
                        .Sum(e => e.Sum(x => x)),
                    Activity = g.Categories.Select(e => e.CategoryInformation.Select(p => p.Activity))
                        .Sum(e => e.Sum(x => x)),
                    Availability = g.Categories.Select(e => e.CategoryInformation.Select(p => p.Available))
                        .Sum(e => e.Sum(x => x)),
                    GroupId = g.GroupId,
                    GroupName = g.GroupName,
                    Categories = g.Categories.Select(e => new CategoryViewModel
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName,
                        CategoryInformation = _mapper.Map<CategoryInformationViewModel>
                        (e.CategoryInformation.FirstOrDefault(x => x.Month.Equals(request.Month)))
                    })
                });

            return model;
        }
    }
}