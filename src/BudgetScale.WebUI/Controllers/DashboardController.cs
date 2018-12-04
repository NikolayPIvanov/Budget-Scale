using System.Threading.Tasks;
using BudgetScale.Application.Groups.Queries.GetCalculatedGroups;
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

            var groups = await Mediator.Send(new GetDashboardGroupsQuery { Month = month, UserId = this.User.GetId() });

            return Ok();
        }
    }
}