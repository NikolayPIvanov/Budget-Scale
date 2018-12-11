﻿using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Categories.Commands.CreateCommand;
using BudgetScale.Application.Categories.Models.Input;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Application.Categories.Queries.GetQuery;
using BudgetScale.Application.CategoryInformation.Commands;
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
                UserId = this.User.GetId(),
                GroupId = groupId,
                CategoryId = categoryId
            });

            if (response == null)
            {
                return NotFound();
            }

            var model = this.Mapper.Map<CategoryViewModel>(response);

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromRoute] string groupId, [FromBody]CreateCommandInputModel model)
        {
            var categoryId = await Mediator.Send(new CreateCategoryCommand
            {
                UserId = this.User.GetId(),
                GroupId = groupId,
                CategoryName = model.CategoryName
            });

            await Mediator.Send(new CreateInformationCommand { Category = categoryId });

            return CreatedAtAction("Get", new { categoryId }, categoryId);

        }
    }
}