// <copyright file="UserRoleInitializer.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Data.Initialize
{
    using PROFiLiX.Web.Shared.Models;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
	/// Class to Initialize the user roles within the identity DB.
	/// </summary>
    public static class UserRoleInitializer
    {
        /// <summary>
        /// Initializes the new roles in the platform.
        /// </summary>
        /// <param name="serviceProvider">The automapper.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Administrator", "HelpDesk", "Reader" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var email = "admin@profilix.com";
            var password = "SuperSecretPassword.123";

            if (userManager.FindByEmailAsync(email).Result == null)
            {
                ApplicationUser user = new ()
                {
                    Email = email,
                    UserName = email,
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result == IdentityResult.Success)
                {
                    userManager.AddToRoleAsync(user, role: "Administrator").Wait();
                }
            }
        }
    }
}
