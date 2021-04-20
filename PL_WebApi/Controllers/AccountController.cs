using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL_WebApi.Models;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        RoleManager<IdentityRole<int>> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
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
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User() { UserName = model.Name, CreateOn = DateTime.Now };
                var createUserResult = await userManager.CreateAsync(newUser, model.Password);

                if (createUserResult.Succeeded)
                {
                    var addtoRoleResult = await userManager.AddToRoleAsync(newUser, "user");

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