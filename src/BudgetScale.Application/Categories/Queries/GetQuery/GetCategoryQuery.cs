using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Categories.Queries.GetQuery
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public string GroupId { get; set; }

        public string CategoryId { get; set; }

        public string UserId { get; set; }

    }
}