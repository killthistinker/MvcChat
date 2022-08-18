using System.Threading.Tasks;
using homework_64.Models;
using Microsoft.AspNetCore.Identity;

namespace homework_64.Services
{
    public static class AdminInitializer
    {
        public static async Task SeedAdminUser(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            string adminEmail = "admin@admin.com";
            string adminPassword = "12345";

            var roles = new[] { "admin", "user" };

            foreach (var role in roles)     
            {
                if (await roleManager.FindByNameAsync(role) is null)
                {
                    await roleManager.CreateAsync(new Role{Name = role});
                }

                if (await  userManager.FindByNameAsync(adminEmail) == null)
                {
                    User admin = new User { Email = adminEmail, UserName = adminEmail};
                    IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "admin");
                    }
                }
            }
        }
    }
}