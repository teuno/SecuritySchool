using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityWebsite.Models;
using System.Linq;


namespace SecurityWebsite.Data
{
    public class DbInitializer
    {
        private const string RoleAdministrator = "Administrator";
        private const string RoleHelpdesk = "Helpdesk";
        private const string RoleNormal = "Normal";

        private readonly string[] _defaultRoles = {RoleAdministrator, RoleHelpdesk, RoleNormal};

        private const string AdminEmail = "administrator@secwindesheim.nl";
        private const string HelpdeskEmail = "helpdesk@secwindesheim.nl";
        private const string NormalEmail = "normal@secwindesheim.nl";
        private const string VeryUnsafeTestPassword = "Welkom01!";

        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public static async Task Run(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var instance = serviceScope.ServiceProvider.GetRequiredService<DbInitializer>();
                await instance.Initialize();
            }
        }

        public DbInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private async Task Initialize()
        {
            _dbContext.Database.Migrate();

            await EnsureRoles();
            await EnsureDefaultUsers();
        }

        private async Task EnsureRoles()
        {
            foreach (var role in _defaultRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private async Task EnsureDefaultUsers()
        {
            await CreateUsersWithRole(RoleAdministrator, AdminEmail);
            await CreateUsersWithRole(RoleHelpdesk, HelpdeskEmail);
            await CreateUsersWithRole(RoleNormal, NormalEmail);
        }

        private async Task CreateUsersWithRole(string role, string email)
        {
            var usersWithRole = await _userManager.GetUsersInRoleAsync(role);

            if (!usersWithRole.Any())
            {
                var user = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };

                await _userManager.CreateAsync(user, VeryUnsafeTestPassword);
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}