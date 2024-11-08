
using EB.Domain.Repositories;
using EB.Persistence.Repositories;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using EB.Persistence.SecurityManagers.Navigations;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace EB.Persistence.SecurityManagers.RoleClaims;

public static class RoleClaimHelper
{
    public static async Task<List<string>> GetPermissionClaims(IMenuRepository repository, List<string> roles)
    {
        var claims = new List<string>();
        var menuList = await NavigationBuilder
            .BuildFinalNavigations(repository, roles);
        foreach (var item in menuList
            .SelectMany(x => x.Children))
        {
            claims.Add($"{item.Name}:Create");
            claims.Add($"{item.Name}:Read");
            claims.Add($"{item.Name}:Update");
            claims.Add($"{item.Name}:Delete");
        }

        return claims;

    }

    public static async Task AddAllClaimsToUser(UserManager<ApplicationUser> userManager, ApplicationUser user, IMenuRepository _menuRepository)
    {
        foreach (var item in (await GetPermissionClaims(_menuRepository, ["SuperAdmin"])))
        {
            await userManager.AddClaimAsync(user, new Claim("Permission", item));
        }
    }

    public static async Task AddAdminRoleToUser(UserManager<ApplicationUser> userManager, ApplicationUser user)
    {
        var roles = new List<string> { "SuperAdmin" };
        foreach (var role in roles)
        {
            if (!await userManager.IsInRoleAsync(user, role))
            {
                var result = await userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                {
                    var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                    throw new RoleClaimException($"Error adding role '{role}' to user: {errorMessages}");
                }
            }
        }
    }

    public static async Task AddBasicRoleToUser(UserManager<ApplicationUser> userManager, ApplicationUser user)
    {
        var roles = new List<string> { "Basic" };
        foreach (var role in roles)
        {
            if (!await userManager.IsInRoleAsync(user, role))
            {
                var result = await userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                {
                    var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                    throw new RoleClaimException($"Error adding role '{role}' to user: {errorMessages}");
                }
            }
        }
    }

}
