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
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        public RoleManager<IdentityRole<int>> RoleManager { get; }

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager,
            SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;

        }

        public async Task<bool> ChangeRoleAsync(string userId, string newRoleId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            var role = await RoleManager.FindByIdAsync(newRoleId);

            if (user != null && role != null)
            {
                bool isInRole = await UserManager.IsInRoleAsync(user, role.Name);

                if (!isInRole)
                {
                    var oldRole = await UserManager.GetRolesAsync(user);
                    await UserManager.RemoveFromRoleAsync(user, oldRole.FirstOrDefault());
                    var result = await UserManager.AddToRoleAsync(user, role.Name);

                    return result.Succeeded;
                }
            }

            return false;
        }

        public User CreateUser(string name)
        {
            return new User() { UserName = name, CreateOn = DateTime.Now };
        }
    }
}
