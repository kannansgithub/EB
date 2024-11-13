using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EB.Persistence.SeedManagers.Systems;

public class IdentitySeeder(
    IOptions<IdentitySettings> identitySettings,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager
    )
{
    private readonly IdentitySettings _identitySettings = identitySettings.Value;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    private async Task GenerateRolesAsync()
    {
        foreach (var role in _identitySettings.DefaultRoles)
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

        if (await _userManager.FindByEmailAsync(adminEmail) == null)
        {
            var applicationUser = new ApplicationUser(
                adminEmail,
                _identitySettings.DefaultAdmin.FirstName,
                _identitySettings.DefaultAdmin.LastName,
                null
                )
            {
                EmailConfirmed = true
            };

            //create user Root Super Admin
            await _userManager.CreateAsync(applicationUser, adminPassword);
            foreach (var role in _identitySettings.DefaultAdmin.Roles)
            {
                //add Defaulr role to the user
                if (!await _userManager.IsInRoleAsync(applicationUser, role))
                {
                    await _userManager.AddToRoleAsync(applicationUser, role);
                }
            }
            
        }
    }
}
