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

        public string Month { get; set; }

        public decimal Budgeted { get; set; }

        public decimal Activity { get; set; }

        public decimal Available { get; set; }

        //public CategoryInformationViewModel CategoryInformation { get; set; }

    }
}