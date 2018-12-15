using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Categories.Queries.GetAllQuery
{
    public class GetAllCategoriesQueryHandler :  IRequestHandler<GetAllCategoriesQuery, IQueryable<Category>>
    {
        public ApplicationDbContext Context { get; }

        public GetAllCategoriesQueryHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IQueryable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = this.Context.Categories
                .Include(c => c.Group)
                .Where(c => c.Group.UserId.Equals(request.UserId));

            return query;
        }

        
    }
}