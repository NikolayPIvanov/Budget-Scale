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
        public async Task<IActionResult> All([FromRoute] string transactionId)
        {
            var response = await Mediator.Send(new GetAllTransactionForAccount
            {
                AccountId = transactionId
            });

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] string transactionId,
            [FromBody] CreateTransactionCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromRoute] string transactionId)
        //{
        //    await Mediator.Send(new Update)
        //}
    }
}