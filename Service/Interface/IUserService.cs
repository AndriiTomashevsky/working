using DataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole<int>> RoleManager { get; }
        Task<bool> ChangeRoleAsync(string userId, string newRoleId);
        User CreateUser(string name);
    }
}
