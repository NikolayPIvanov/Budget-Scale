using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Accounts.Models.Output;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [ApiController]
    [Route("/api/accounts")]
    public class AccountsController : BaseController
    {
        public async Task<IActionResult> All()
        {
            var response = await Mediator.Send(new GetAllAccountsQuery(User.GetId()));

            var model = response.ProjectTo<AccountsViewModel>(Mapper.ConfigurationProvider);

            return Ok(model);
        }
    }
}