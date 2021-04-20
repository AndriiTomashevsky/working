using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL_WebApi.Models;
using Service;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.UserManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await userService.SignInManager.SignOutAsync();
                    var result = await userService.SignInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        var roles = await userService.UserManager.GetRolesAsync(user);
                        return Ok($"You has been logged in as {roles.FirstOrDefault()}");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Failed to login");
                    }
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.SignInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = userService.CreateUser(model.Name);
                var createUserResult = await userService.UserManager.CreateAsync(newUser, model.Password);

                if (createUserResult.Succeeded)
                {
                    var addtoRoleResult = await userService.UserManager.AddToRoleAsync(newUser, "user");

                    if (addtoRoleResult.Succeeded)
                    {
                        return Ok("You has been registered successfully");
                    }
                }

                AddErrors(createUserResult);
            }

            return BadRequest(ModelState);
        }

        void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }
    }
}