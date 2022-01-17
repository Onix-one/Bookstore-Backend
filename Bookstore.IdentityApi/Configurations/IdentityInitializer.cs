using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bookstore.IdentityApi.Configurations
{
    public static class IdentityInitializer
    {
        private static UserManager<User> _userManager;
        private static RoleManager<IdentityRole> _roleManager;

        public static async Task InitializeAsync(IServiceProvider serviceProvider,
            IOptions<InitializerOptions> initializerOptions)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminEmail = initializerOptions.Value.AdminEmail;
            var adminPassword = initializerOptions.Value.AdminPassword;

            var roles = new List<string> { "admin", "manager", "customer" };

            foreach (var role in roles)
                if (await _roleManager.FindByNameAsync(role) == null)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            if (await _userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User
                {
                    LastName = "Admin",
                    FirstName = "Alex",
                    Email = adminEmail,
                    UserName = adminEmail,
                };
                var result = await _userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded) await _userManager.AddToRoleAsync(admin, "admin");
            }

            var managerEmail = initializerOptions.Value.ManagerEmail;
            var managerPassword = initializerOptions.Value.ManagerPassword;

            if (await _userManager.FindByNameAsync(managerEmail) == null)
            {
                var user = new User
                {
                    LastName = "Manager",
                    FirstName = "John",
                    Email = managerEmail,
                    UserName = managerEmail,
                };
                var result = await _userManager.CreateAsync(user, managerPassword);
                if (result.Succeeded) await _userManager.AddToRoleAsync(user, "manager");
            }

            var customerEmail = initializerOptions.Value.CustomerEmail;
            var customerPassword = initializerOptions.Value.CustomerPassword;

            if (await _userManager.FindByNameAsync(customerEmail) == null)
            {
                var user = new User
                {
                    LastName = "Customer",
                    FirstName = "Ronny",
                    Email = customerEmail,
                    UserName = customerEmail,
                };
                var result = await _userManager.CreateAsync(user, customerPassword);
                if (result.Succeeded) await _userManager.AddToRoleAsync(user, "customer");
            }
        }
    }
}