using MediatR;

namespace BudgetScale.Application.CategoryInformation.Queries.GetQuery
{
    public class GetCategoryInformationQuery : IRequest<Domain.Entities.CategoryInformation>
    {
        public string CategoryInformationId { get; set; }

    }
}