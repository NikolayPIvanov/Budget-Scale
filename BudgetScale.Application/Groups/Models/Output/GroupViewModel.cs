using System.Collections.Generic;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Domain.Entities;
using BudgetScale.Infrastructure.Mapping;

namespace BudgetScale.Application.Groups.Models.Output
{
    public class GroupViewModel : IMapFrom<Group>
    {
        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}