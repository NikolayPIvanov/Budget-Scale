using System.Linq;
using System.Threading.Tasks;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;
using BudgetScale.Domain.Entities;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DashboardController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<IActionResult> RequestData([FromQuery] string month)
        {
            // Include groups with categories with information and map them to a dto.
            // Include accounts with transactions
            // Calculate budget, activity, availability, month's inflow, to be budgeted

            var userId = this.User.GetId();

            var groups = await Mediator.Send(new GetDashboardGroupsQuery { Month = month, UserId = userId });

            //TODO: Add months
            var accounts = await Mediator.Send(new GetAllAccountsQuery(userId));

            var toBeBudgeted = accounts.Sum(e => e.Transactions
                                   .Where(c => c.Type == TransactionType.Outflow).Sum(c => c.Amount )) 
                               - groups.Sum(e => e.Availability);

            
            return Ok();
        }
    }
}