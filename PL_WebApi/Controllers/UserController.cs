using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> ChangeRole(string userId, [FromBody]string newRoleId)
        {
            if (newRoleId != null)
            {
                var succeeded = await userService.ChangeRoleAsync(userId, newRoleId);

                if (succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}