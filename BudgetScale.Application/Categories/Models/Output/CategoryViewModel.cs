using System.Collections.Generic;

namespace BudgetScale.Application.Groups.Models.Output
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CategoryInformationViewModel> CategoryInformation { get; set; }


    }
}