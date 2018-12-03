using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQuery : IRequest<IQueryable<Group>>
    {
        public string UserId { get; set; }

        public string Month { get; set; }


    }
}