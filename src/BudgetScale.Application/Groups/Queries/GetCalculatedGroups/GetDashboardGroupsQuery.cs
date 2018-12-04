using System.Collections.Generic;
using BudgetScale.Application.Groups.Models.Output;
using MediatR;

namespace BudgetScale.Application.Groups.Queries.GetCalculatedGroups
{
    public class GetDashboardGroupsQuery : IRequest<IEnumerable<GroupDashboardViewModel>>
    {
        public string UserId { get; set; }

        public string Month { get; set; }
    }
}   