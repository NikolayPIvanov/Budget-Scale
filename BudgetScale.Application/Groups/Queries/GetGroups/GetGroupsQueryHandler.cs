﻿using System.Collections.Generic;
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
    public class GetGroupsQueryHandler : BaseEntity, IRequestHandler<GetGroupsQuery, IEnumerable<GroupViewModel>>
    {
        public GetGroupsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<GroupViewModel>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {

            _context.Filter<Group>(i => i.Where(g => g.UserId.Equals(request.UserId)));

            _context.Filter<Domain.Entities.CategoryInformation>(i => i.Where(g => g.Month.Equals(request.Month)));

            var groups = await this._context.Groups
               .Include(g => g.Categories)
               .ThenInclude(e => e.CategoryInformation)
                //.ProjectTo<GroupViewModel>(_mapper.ConfigurationProvider)
                .Select(group => new GroupViewModel
                {
                    GroupName = group.GroupName,
                    GroupId = group.GroupId,
                    Categories = group.Categories.Select(category => new CategoryViewModel
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryId,
                        CategoryInformation = category.
                        CategoryInformation
                            .Where(info => info.Month.Equals(request.Month))
                            .Select(info => _mapper.Map<CategoryInformationViewModel>(info))
                            .FirstOrDefault(e => e.Month.Equals(request.Month))
                    })
                })
               .ToListAsync(cancellationToken: cancellationToken);

            return groups;

        }


    }
}