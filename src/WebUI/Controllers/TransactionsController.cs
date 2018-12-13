using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Transactions.Commands.Create;
using BudgetScale.Application.Transactions.Model;
using BudgetScale.Application.Transactions.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/api/{accountId}/transactions")]
    public class TransactionsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All([FromRoute] string accountId)
        {
            var response = await Mediator.Send(new GetAllTransactionForAccount
            {
                AccountId = accountId
            });

            return Ok(response);
        }
                
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] string accountId,
            [FromBody] CreateTransactionCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}