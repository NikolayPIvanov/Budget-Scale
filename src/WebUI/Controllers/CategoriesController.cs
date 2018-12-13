using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Categories.Commands.CreateCommand;
using BudgetScale.Application.Categories.Commands.DeleteCommand;
using BudgetScale.Application.Categories.Commands.Update;
using BudgetScale.Application.Categories.Models.Input;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Application.Categories.Queries.GetQuery;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/{groupId}/categories/")]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> All([FromRoute]string groupId)
        {
            var response = await Mediator.Send(new GetAllCategoriesQuery { UserId = this.User.GetId(), GroupId = groupId });

            if (response == null)
            {
                return Unauthorized();
            }

            var model = response.ProjectTo<CategoryViewModel>(Mapper.ConfigurationProvider);

            return Ok(model);
        }


        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get([FromRoute] string groupId, [FromRoute] string categoryId)
        {
            var response = await Mediator.Send(new GetCategoryQuery
            {
                GroupId = groupId,
                CategoryId = categoryId
            });

            
            if (response == null)
            {
                return NotFound();
            }

            if (response.Group.UserId != this.User.GetId())
            {
                return Unauthorized();

            }

            var model = this.Mapper.Map<CategoryViewModel>(response);

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromRoute] string groupId, [FromBody]CreateCommandInputModel model)
        {
            var categoryId = await Mediator.Send(new CreateCategoryCommand
            {
                UserId = this.User.GetId(),
                GroupId = groupId,
                CategoryName = model.CategoryName,
                Month = DateTime.Now.ToString("MMM")
            });

            //return CreatedAtAction("Get", new { groupId, categoryId }, new {groupId,categoryId});
            return Ok(categoryId);

        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromRoute] string categoryId, [FromBody] UpdateCategoryCommand command)
        {
            if (categoryId != command.CategoryId)
            {
                return BadRequest();
            }
            //TODO : Add validator

            await Mediator.Send(command);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] string categoryId)
        {
            await Mediator.Send(new DeleteCategoryCommand {CategoryId = categoryId});

            return NoContent();
        }


    }
}