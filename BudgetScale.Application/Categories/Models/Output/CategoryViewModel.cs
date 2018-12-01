using System.Collections.Generic;
using BudgetScale.Application.CategoryInformation.Models.Output;

namespace BudgetScale.Application.Categories.Models.Output
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CategoryInformationViewModel> CategoryInformation { get; set; }


    }
}