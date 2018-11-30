using System.Collections;
using System.Collections.Generic;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Queries
{
    public class GetGroupsQuery : IRequest<IEnumerable<Group>>
    {
        public string UserId { get; set; }

        public string Month { get; set; }


    }
}