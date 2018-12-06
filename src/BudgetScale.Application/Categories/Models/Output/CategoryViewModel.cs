using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BudgetScale.Application.CategoryInformation.Models.Output;
using BudgetScale.Domain.Entities;
namespace BudgetScale.Application.Categories.Models.Output
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryInformationViewModel CategoryInformation { get; set; }

    }
}