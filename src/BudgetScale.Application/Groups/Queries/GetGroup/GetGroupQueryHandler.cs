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

namespace BudgetScale.Application.Groups.Queries.GetGroup
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, Group>
    {
        private readonly ApplicationDbContext _context;

        public GetGroupQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var model = await this._context.Groups
                .Include(g => g.Categories)
                .ThenInclude(e => e.CategoryInformation)
                .FirstOrDefaultAsync(e => e.GroupId.Equals(request.GroupId), cancellationToken: cancellationToken);

            //Filter
            if (model == null) return model;

            foreach (var category in model.Categories)
            {
                category.CategoryInformation = category.CategoryInformation
                    .Where(e => e.Month.Equals(request.Month)).ToList();
            }


            return model;
        }
    }
}