using DataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        UserManager<User> userManager;
        RoleManager<IdentityRole<int>> roleManager;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> ChangeRoleAsync(string userId, string newRoleId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var role = await roleManager.FindByIdAsync(newRoleId);

            if (user != null && role != null)
            {
                bool isInRole = await userManager.IsInRoleAsync(user, role.Name);

                if (!isInRole)
                {
                    var oldRole = await userManager.GetRolesAsync(user);
                    await userManager.RemoveFromRoleAsync(user, oldRole.FirstOrDefault());
                    var result = await userManager.AddToRoleAsync(user, role.Name);

                    return result.Succeeded;
                }
            }

            return false;
        }
    }
}
