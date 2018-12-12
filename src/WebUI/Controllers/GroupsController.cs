using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Models.Input.Create;
using BudgetScale.Application.Groups.Models.Input.UpdatePartially;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;
using BudgetScale.Application.Groups.Queries.GetGroup;
using BudgetScale.Application.Groups.Queries.GetGroups;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPatch("{groupId}")]
        public async Task<IActionResult> PartiallyUpdateGroup([FromRoute] string groupId,
            [FromBody] JsonPatchDocument<GroupForUpdateDto> patchDto,
            [FromQuery] string month = "Dec")
        {
            if (patchDto == null)
            {
                return BadRequest();
            }

            var groupFromDatabase = await Mediator.Send(new GetGroupQuery
            {
                GroupId = groupId,
                Month = month
            });

            if (groupFromDatabase == null)
            {
                return NotFound();
            }

            //TODO:;
            //patchDto.ApplyTo(groupFromDatabase);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {

            await Mediator.Send(new DeleteCategoryCommand { CategoryId = id });

            return NoContent();
        }


    }
}