

using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Models.Input;
using BudgetScale.Application.Groups.Models.Input.Create;
using BudgetScale.Application.Groups.Queries.GetGroup;
using BudgetScale.Application.Groups.Queries.GetGroups;

namespace BudgetScale.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Application.Groups.Models.Output;
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
        public async Task<IActionResult> All([FromQuery] string month = "Dec")
        {
            var request = new GetGroupsQuery {Month = month, UserId = this.User.GetId()};
            var response = await Mediator.Send(request);

            return Ok(response);    
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> Get([FromRoute] string groupId, [FromQuery] string month = "Dec")
        {
            var response = await Mediator.Send(new GetGroupQuery
            {
                UserId = this.User.GetId(),
                Month = month,
                GroupId = groupId
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommandInputModel model)
        {
            var groupId = await Mediator.Send(new CreateGroupCommand
            {
                GroupName = model.GroupName,
                UserId = this.User.GetId()
            });
            
            return this.CreatedAtAction("Get", new {groupId});
        }

        
    }
}