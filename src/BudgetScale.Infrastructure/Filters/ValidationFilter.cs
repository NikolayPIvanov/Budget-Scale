using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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