using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;


namespace BudgetScale.Infrastructure.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static string GetFirstError(this ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            return modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).FirstOrDefault();
        }

        public static bool ExcludeAndValidate(this ModelStateDictionary modelState, params object[] args)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            foreach (object argument in args)
            {
                modelState.Remove(nameof(argument));
            }

            return modelState.IsValid;
        }
    }
}