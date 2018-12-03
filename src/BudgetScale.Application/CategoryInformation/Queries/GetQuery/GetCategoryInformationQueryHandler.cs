using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.CategoryInformation.Queries.GetQuery
{
    public class GetCategoryInformationQueryHandler : BaseHandler, 
        IRequestHandler<GetCategoryInformationQuery,Domain.Entities.CategoryInformation>
    {
        public GetCategoryInformationQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Domain.Entities.CategoryInformation> Handle(GetCategoryInformationQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.CategoryInformations.FirstOrDefaultAsync(e =>
                e.CategoryInformationId.Equals(request.CategoryInformationId), cancellationToken: cancellationToken);

            return model;
        }
    }
}