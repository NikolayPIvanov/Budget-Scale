using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;


namespace BudgetScale.Infrastructure.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static string GetFirstError(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).FirstOrDefault();
        }
    }
}