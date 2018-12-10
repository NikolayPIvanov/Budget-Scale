using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [ApiController]
    [Route("/api/{accountId}/transactions")]
    public class TransactionsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            return Ok();
        }
    }
}