using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Requests.Models.Output;
using BudgetScale.Application.Requests.Queries.AllRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    [Authorize(Policy = "Administrator")]
    [ApiController]
    [Route("api/services/requests")]
    public class RequestsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetRequests(int hours = int.MaxValue)
        {
            var query = await Mediator.Send(new AllRequests {Hours = hours});

            return Ok(query.ProjectTo<RequestViewModel>(Mapper.ConfigurationProvider));
        }
        
    }
}