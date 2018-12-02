using System.Collections.Generic;
using BudgetScale.Application.Categories.Models.Output;

namespace BudgetScale.Application.Groups.Models.Output
{
    public class GroupViewModel 
    {
        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}