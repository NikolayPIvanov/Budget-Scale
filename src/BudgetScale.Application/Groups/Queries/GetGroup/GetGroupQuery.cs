using System.Collections.Generic;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Groups.Queries.GetGroup
{
    public class GetGroupQuery : IRequest<Group>
    {
        public string Month { get; set; }

        public string GroupId { get; set; }
    }
}