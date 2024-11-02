using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EB.Persistence.SeedManagers.Systems;

public class IdentitySeeder(
    IOptions<IdentitySettings> identitySettings,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
{
    private readonly IdentitySettings _identitySettings = identitySettings.Value;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    private async Task GenerateRolesAsync()
    {
        List<string> roles = ["SuperAdmin", "Admin", "Basic"];
        foreach (var role in roles)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
            {
                var applicationRole = new IdentityRole(role.Trim());
                await _roleManager.CreateAsync(applicationRole);
            }
        }
    }
    public async Task GenerateDataAsync()
    {
        await GenerateRolesAsync();
        var adminEmail = _identitySettings.DefaultAdmin.Email;
        var adminPassword = _identitySettings.DefaultAdmin.Password;

        var adminRole = "SuperAdmin";
        var basicRole = "Basic";
        if (await _userManager.FindByEmailAsync(adminEmail) == null)
        {
            var applicationUser = new ApplicationUser(
                adminEmail,
                "Root",
                "SuperAdmin",
                null
                )
            {
                EmailConfirmed = true
            };

            //create user Root Super Admin
            await _userManager.CreateAsync(applicationUser, adminPassword);

            //add Super Admin role to Root Super Admin
            if (!await _userManager.IsInRoleAsync(applicationUser, adminRole))
            {
                await _userManager.AddToRoleAsync(applicationUser, adminRole);
            }

            //add Basic role to Root Super Admin
            if (!await _userManager.IsInRoleAsync(applicationUser, basicRole))
            {
                await _userManager.AddToRoleAsync(applicationUser, basicRole);
            }

        }
    }
}
