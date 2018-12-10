


using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Groups.Models.Input.UpdatePartially;
using BudgetScale.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace BudgetScale.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Infrastructure.Extensions;
    using Application.Groups.Models.Output;
    using Application.Groups.Commands.CreateCommand;
    using Application.Groups.Models.Input.Create;
    using Application.Groups.Queries.GetGroup;
    using Application.Groups.Queries.GetGroups;

    using Microsoft.AspNetCore.Mvc;
    using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;

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
                UserId = this.User.GetId(),
                GroupId = groupId
            });

            var model = Mapper.Map<GroupViewModel>(response);

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
                UserId = this.User.GetId(),
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


    }
}