using System.Linq;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using BudgetScale.Application.Users;
using Microsoft.AspNetCore.Authorization;

namespace BudgetScale.WebUI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
                //  return this.BadRequest(this.ModelState.GetFirstError());
            }

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email, FullName = model.FullName };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            if (this.userManager.Users.Count() == 1)
            {
                await this.userManager.AddToRoleAsync(user, "Administrator");

            }
            else
            {
                await this.userManager.AddToRoleAsync(user, "User");

            }

            return this.BadRequest(result);
        }
    }
}