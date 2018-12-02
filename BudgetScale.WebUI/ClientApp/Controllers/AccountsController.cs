using System.Linq;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using BudgetScale.Application.Users;
using BudgetScale.Infrastructure.Extensions;

namespace BudgetScale.WebUI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email, FullName = model.FullName };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return this.BadRequest(result);

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