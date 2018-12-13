using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Categories.Commands.DeleteCommand;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Commands.DeleteCommand;
using BudgetScale.Application.Groups.Models.Input;
using BudgetScale.Application.Groups.Models.Input.Create;
using BudgetScale.Application.Groups.Models.Input.UpdatePartially;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;
using BudgetScale.Application.Groups.Queries.GetGroup;
using BudgetScale.Application.Groups.Queries.GetGroups;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GroupViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> All([FromQuery] string month = "Dec")
        {
            var query = await Mediator.Send(new GetGroupsQuery { Month = month, UserId = this.User.GetId() });

            var response = query.ProjectTo<GroupViewModel>(Mapper.ConfigurationProvider);

            return Ok(response);
        }

        [HttpGet("shaped")]
        public async Task<IActionResult> GetCalculatedGroups([FromQuery] string month = "Dec")
        {
            var query = await Mediator.Send(new GetDashboardGroupsQuery { Month = month, UserId = this.User.GetId() });

            return Ok(query);
        }

        [HttpGet("{groupId}")]
        [ProducesResponseType(typeof(GroupViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get([FromRoute] string groupId)
        {
            var response = await Mediator.Send(new GetGroupQuery
            {
                GroupId = groupId
            });

            if (response == null)
            {
                return NotFound();
            }

            if (response.UserId != this.User.GetId())
            {
                return Unauthorized();
            }

            var model = AutoMapper.Mapper.Map<GroupViewModel>(response);

            return Ok(model);
        }
        

        [HttpPost]
        [ProducesResponseType(typeof(CreatedAtActionResult), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CommandInputModel model)
        {
            var groupId = await Mediator.Send(new CreateGroupCommand
            {
                GroupName = model.GroupName,
                UserId = this.User.GetId(),
            });

            return this.CreatedAtAction("Get", new { groupId = groupId }, new { groupId = groupId });
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateGroupCommand update)
        {
            await Mediator.Send(update);
            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            // add validation
            await Mediator.Send(new DeleteGroupCommand { GroupId = id });

            return NoContent();
        }


    }
}