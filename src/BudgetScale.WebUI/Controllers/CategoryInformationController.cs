using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetScale.Application.CategoryInformation.Queries.GetQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{groupId}/categories/{categoryId}/")]
    public class CategoryInformationController : BaseController
    {
        public async Task<IActionResult> Get(
            [FromRoute] string groupId,
            [FromRoute] string categoryId,
            [FromRoute] string categoryInformationId)
        {
            var response = await Mediator.Send(new GetCategoryInformationQuery
            {
                CategoryInformationId = categoryInformationId
            });

            if (response == null)
            {
                return NotFound();
            }


            //TODO: To be finished
            return Ok(response);
        }
    }
}