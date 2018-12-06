using System.Linq;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using BudgetScale.Application.Users;
using BudgetScale.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace BudgetScale.WebUI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(System.Collections.Generic.IEnumerable<IdentityError>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel model)
        {
            var user = new ApplicationUser { Email = model.Email, UserName = model.Email, FullName = model.FullName };

            var result = await this._userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return this.BadRequest(result.Errors);

            if (this._userManager.Users.Count() == 1)
            {
                await this._userManager.AddToRoleAsync(user, "Administrator");
            }
            else
            {
                await this._userManager.AddToRoleAsync(user, "User");
            }

            return this.Ok();
        }
    }
}