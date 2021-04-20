using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("changerole/{userId}")]
        public async Task<IActionResult> ChangeRole(string userId, [FromBody, Required]string newRoleId)
        {
            if (ModelState.IsValid)
            {
                var succeeded = await userService.ChangeRoleAsync(userId, newRoleId);

                if (succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest(ModelState);
        }
    }
}