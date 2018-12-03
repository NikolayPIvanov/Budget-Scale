
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [ApiController]
    [Route("api/{groupId}/")]
    public class CategoriesController : BaseController
    {
        [HttpGet("{groupId}")]
        public async Task<IActionResult> All([FromRoute]string groupId)
        {
            var response = await Mediator.Send(new GetAllCategoriesQuery{UserId = this.User.GetId(),GroupId = groupId});

            var model = Mapper.Map<CategoryViewModel>(response);

            return Ok(model);
        }
    }
}