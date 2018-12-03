
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Commands.CreateCommand;
using BudgetScale.Application.Categories.Models.Input;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Application.Categories.Queries.GetQuery;
using BudgetScale.Application.Groups.Commands.CreateCommand;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] string groupId, [FromBody]CreateCommandInputModel model)
        {
            var categoryId = await Mediator.Send(new CreateCategoryCommand
            {
                UserId = this.User.GetId(),
                GroupId = groupId,
                CategoryName = model.CategoryName
            });

            return CreatedAtAction("Get", new {categoryId});

        }
    }
}