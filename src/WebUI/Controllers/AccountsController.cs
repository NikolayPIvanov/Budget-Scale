using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Accounts.Commands;
using BudgetScale.Application.Accounts.Commands.CreateCommand;
using BudgetScale.Application.Accounts.Commands.DeleteCommand;
using BudgetScale.Application.Accounts.Commands.UpdateCommand;
using BudgetScale.Application.Accounts.Models.Input;
using BudgetScale.Application.Accounts.Models.Output;
using BudgetScale.Application.Accounts.Queries.GetAccount;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Application.Accounts.Validator;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var response = await Mediator.Send(new GetAllAccountsQuery(User.GetId()));

            var model = response.ProjectTo<AccountsViewModel>(Mapper.ConfigurationProvider);

            return Ok(model);
        }

        [HttpGet("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get([FromRoute] string accountId)
        {
            var response =
                await Mediator.Send(new GetAccountQuery() { AccountId = accountId });

            if (response == null)
            {
                return NotFound();
            }

            if (response.UserId != this.User.GetId())
            {
                return Unauthorized();
            }

            var model = Mapper.Map<AccountsViewModel>(response);

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateAccountViewModel account)
        {
            var accountId = await Mediator.Send(new CreateAccountCommand
            {
                UserId = this.User.GetId(),
                AccountName = account.Name,
                AccountType = account.Type
            });

            return this.CreatedAtAction("Get", new { accountId }, new { accountId });

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateAccountCommand command)
        {
            if (id != command.AccountId)
            {
                return BadRequest();
            }

            (bool exists, bool authorized) = await Mediator.Send(new ValidatorRequest
            {
                AccountId = id,
                UserId = this.User.GetId()
            });

            if (!exists)
            {
                return NotFound();
            }

            if (!authorized)
            {
                return Unauthorized();
            }

            await Mediator.Send(command);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            (bool exists, bool authorized) = await Mediator.Send(new ValidatorRequest
            {
                AccountId = id,
                UserId = this.User.GetId()
            });

            if (!exists)
            {
                return NotFound();
            }

            if (!authorized)
            {
                return Unauthorized();
            }

            await Mediator.Send(new DeleteAccountCommand {AccountId = id});
            
            return NoContent();
        }
    }
}