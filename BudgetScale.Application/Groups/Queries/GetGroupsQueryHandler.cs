using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Groups.Queries
{
    public class GetGroupsQueryHandler : BaseEntity, IRequestHandler<GetGroupsQuery, IEnumerable<Group>>
    {
        public GetGroupsQueryHandler(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {

        }

        
    }
}