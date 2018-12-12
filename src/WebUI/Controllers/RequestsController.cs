using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BudgetScale.Application.Requests.Models.Output;
using BudgetScale.Application.Requests.Queries.AllRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Policy = "Administrator")]
    [ApiController]
    [Route("api/services/requests")]
    public class RequestsController : BaseController
    {
        
    }
}