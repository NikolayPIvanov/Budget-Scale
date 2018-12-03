using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.CategoryInformation.Models.Output;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQueryHandler : BaseEntity, IRequestHandler<GetGroupsQuery, IQueryable<Group>>
    {
        public GetGroupsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IQueryable<Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            _context.Filter<Group>(i => i.Where(g => g.UserId.Equals(request.UserId)));

            var groups = this._context.Groups
                .Include(g => g.Categories)
                .ThenInclude(e => e.CategoryInformation);

            foreach (var group in groups)
            {
                foreach (var category in group.Categories)
                {
                    category.CategoryInformation = category.CategoryInformation
                        .Where(e => e.Month.Equals(request.Month)).ToList();
                }
            }

            return groups;

        }


    }
}