using System.Collections.Generic;
using BudgetScale.Application.Groups.Models.Output;
using MediatR;

namespace BudgetScale.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQuery : IRequest<IEnumerable<GroupViewModel>>
    {
        public string UserId { get; set; }

        public string Month { get; set; }


    }
}