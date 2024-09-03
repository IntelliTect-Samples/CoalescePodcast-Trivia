using IntelliTect.Trivia.Data;
using IntelliTect.Trivia.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace IntelliTect.Trivia.Web.Identity;

public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Editor))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Editor));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        if (await userManager.FindByEmailAsync("Editor@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Editor@intellitect.com",
                Email = "Editor@intellitect.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Editor);
            }
        }
    }
}