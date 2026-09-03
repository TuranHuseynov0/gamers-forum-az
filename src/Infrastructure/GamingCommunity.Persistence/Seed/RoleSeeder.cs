using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Persistence.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRole(RoleManager<IdentityRole<Guid>> roleManager)
        {
            string[] roles =
            {
                "User",
                "Moderator",
                "Admin"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole<Guid>(role));
                }
            }
        }
    }
}
