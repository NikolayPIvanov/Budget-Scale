using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Accounts.Commands;
using BudgetScale.Application.Accounts.Models.Input;
using BudgetScale.Application.Accounts.Models.Output;
using BudgetScale.Application.Accounts.Queries.GetAccount;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/api/accounts")]
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
                await Mediator.Send(new GetAccountQuery() { UserId = this.User.GetId(), AccountId = accountId });

            if (response == null)
            {
                return NotFound();
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
    }
}