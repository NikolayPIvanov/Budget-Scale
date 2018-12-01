using System.Collections.Generic;
using BudgetScale.Application.Groups.Models.Output;
using MediatR;

namespace BudgetScale.Application.Groups.Queries.GetGroup
{
    public class GetGroupQuery : IRequest<GroupViewModel>
    {
        public string UserId { get; set; }

        public string Month { get; set; }

        public string GroupId { get; set; }
    }
}