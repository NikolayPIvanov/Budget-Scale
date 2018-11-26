namespace BudgetScale.Persistence.Infrastructure
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            Seed(dbContext, roleManager);
        }

        public static void Seed(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            SeedRoles(roleManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            SeedRole("Administrator", roleManager);
            SeedRole("User", roleManager);
            SeedRole("Support", roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<IdentityRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();

            if (role == null)
            {
                var result = roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}