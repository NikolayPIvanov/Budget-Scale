

namespace BudgetScale.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Application.Groups.Models.Output;
    using Application.Groups.Queries;
    using Infrastructure.Extensions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GroupViewModel>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> All([FromQuery] string month)
        {
            var response = await Mediator.Send(new GetGroupsQuery {Month = month, UserId = this.User.GetId()});

            return Ok(response);
        }
    }
}