using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BudgetScale.Infrastructure.Extensions;

namespace BudgetScale.Infrastructure.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            var list = (from modelState in context.ModelState.Values
                        from error in modelState.Errors select error.ErrorMessage).ToList();
            context.Result = new BadRequestObjectResult(list);

        }

    }
}