﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.CategoryInformation.Models.Output;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Groups.Queries
{
    public class GetGroupsQueryHandler : BaseEntity, IRequestHandler<GetGroupsQuery, IEnumerable<GroupViewModel>>
    {
        public GetGroupsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context,mapper)
        {
        }

        public async Task<IEnumerable<GroupViewModel>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            List<GroupViewModel> groups = await this._context.Groups.AsNoTracking()
                .Where(group => group.UserId.Equals(request.UserId))
                .Include(g => g.Categories)
                .ThenInclude(c => c.CategoryInformation
                    .Where(e => e.Month
                        .Equals(request.Month)))
                .ProjectTo<GroupViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return groups;

            /*.Select(group => new GroupViewModel
            {
                GroupName = group.GroupName,
                GroupId = group.GroupId,
                Categories = group.Categories.Select(category => new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryId,
                    CategoryInformation = category.
                        CategoryInformation.Where(info => info.Month.Equals(request.Month))
                        .Select(info => new CategoryInformationViewModel
                    {
                        Activity = info.Activity,
                        Available = info.Available,
                        Budgeted = info.Budgeted,
                        CategoryInformationId = info.CategoryInformationId,
                        Month = info.Month
                    })
                })
            })
            */




        }

        
    }
}