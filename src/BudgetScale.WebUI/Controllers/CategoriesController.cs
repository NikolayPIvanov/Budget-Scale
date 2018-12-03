
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Application.Categories.Queries.GetQuery;
using BudgetScale.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [ApiController]
    [Route("api/{groupId}/categories/")]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All([FromRoute]string groupId)
        {
            // TODO: Add validaton
            var response = await Mediator.Send(new GetAllCategoriesQuery{UserId = this.User.GetId(),GroupId = groupId});

            var model = Mapper.Map<CategoryViewModel>(response);

            return Ok(model);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get([FromRoute] string groupId, [FromRoute] string categoryId)
        {
            var response = await Mediator.Send(new GetCategoryQuery
            {
                UserId = this.User.GetId(),
                GroupId = groupId,
                CategoryId = categoryId
            });

            var model = this.Mapper.Map<CategoryViewModel>(response);

            return Ok(model);
        }
    }
}