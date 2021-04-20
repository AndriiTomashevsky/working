using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class IdentitySeedData
    {
        const string adminName = "admin";
        const string adminPassword = "admin";
        const string adminRole = "Admin";

        static string[] roles = new string[] { "User", "Moderator" };

        public static async Task SeedDatabase(IServiceProvider provider)
        {
            provider.GetRequiredService<ApplicationContext>().Database.Migrate();

            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            var role = await roleManager.FindByNameAsync(adminRole);
            var user = await userManager.FindByNameAsync(adminName);

            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole<int>(adminRole));
                if (!result.Succeeded)
                    throw new Exception($"Cannot create role: {result.Errors.FirstOrDefault().Description}");
            }

            if (user == null)
            {
                user = new User() { UserName = adminName };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception($"Cannot create user: {result.Errors.FirstOrDefault().Description}");
            }

            if (!await userManager.IsInRoleAsync(user, adminRole))
            {
                var result = await userManager.AddToRoleAsync(user, adminRole);
                if (!result.Succeeded)
                    throw new Exception($"Cannot add user to role: {result.Errors.FirstOrDefault().Description}");
            }

            foreach (var item in roles)
            {
                var roleUser = await roleManager.FindByNameAsync(item);

                if (roleUser == null)
                {
                    var result = await roleManager.CreateAsync(new IdentityRole<int>(item));
                    if (!result.Succeeded)
                        throw new Exception($"Cannot create role: {result.Errors.FirstOrDefault().Description}");
                }
            }
        }
    }
}
