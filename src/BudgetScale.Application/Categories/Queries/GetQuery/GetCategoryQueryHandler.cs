using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Categories.Queries.GetQuery
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        public ApplicationDbContext Context { get; }

        public GetCategoryQueryHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var model = await this.Context.Categories
                .Include(c => c.Group)
                .Where(e => e.GroupId.Equals(request.GroupId))
                .FirstOrDefaultAsync(c =>
                    c.CategoryId.Equals(request.CategoryId), cancellationToken: cancellationToken);

            return model;
        }

    }
}