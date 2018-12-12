using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Categories.Queries.GetQuery
{
    public class GetCategoryQueryHandler : BaseHandler, IRequestHandler<GetCategoryQuery, Category>
    {
        public GetCategoryQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var model = await this._context.Categories
                .Include(c => c.Group)
                .Where(e => e.GroupId.Equals(request.GroupId))
                .FirstOrDefaultAsync(c =>
                    c.CategoryId.Equals(request.CategoryId), cancellationToken: cancellationToken);

            return model;
        }

    }
}