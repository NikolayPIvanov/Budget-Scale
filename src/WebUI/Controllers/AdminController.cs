using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;
using BudgetScale.Application.Requests.Models.Output;
using BudgetScale.Application.Requests.Queries.AllRequests;
using BudgetScale.Application.Transactions.Model;
using BudgetScale.Application.Transactions.Query;
using BudgetScale.Application.Transactions.Query.TransactionsForUser;
using BudgetScale.Domain.Entities;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Policy = "Administrator")]
    [ApiController]
    [Route("/api/[controller]")]
    public class AdminController : BaseController
    {
        // GET
        //[HttpGet]
        //public async Task<IActionResult> RequestData([FromQuery] string month)
        //{
        //    // Include groups with categories with information and map them to a dto.
        //    // Include accounts with transactions
        //    // Calculate budget, activity, availability, month's inflow, to be budgeted

        //    var userId = this.User.GetId();

        //    var groups = await Mediator.Send(new GetDashboardGroupsQuery { Month = month, UserId = userId });

        //    //TODO: Add months
        //    var accounts = await Mediator.Send(new GetAllAccountsQuery(userId));

        //    var toBeBudgeted = accounts.Sum(e => e.Transactions
        //                           .Where(c => c.Type == TransactionType.Outflow).Sum(c => c.Amount))
        //                       - groups.Sum(e => e.Availability);

        //    return Ok();
        //}

        [HttpGet]
        public async Task<IActionResult> AllTransactions()
        {
            var response = await Mediator.Send(new GetAllTransaction());
            return Ok(response.ProjectTo<TransactionViewModel>(Mapper.ConfigurationProvider));
        }

        [HttpGet()]
        public async Task<IActionResult> TransactionForUser([FromRoute] string userId)
        {
            var response = await Mediator.Send(new GetTransactionsForUserQuery { UserId = userId });

            return Ok(response.ProjectTo<TransactionViewModel>(Mapper.ConfigurationProvider));
        }

        [HttpGet]
        public async Task<IActionResult> GetRequests([FromQuery]int hours = int.MaxValue)
        {
            var query = await Mediator.Send(new AllRequests { Hours = hours });

            return Ok(query.ProjectTo<RequestViewModel>(Mapper.ConfigurationProvider));
        }
        
        
    }
}