
using EB.Domain.Repositories;
using EB.Domain.Services;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using EB.Persistence.SecurityManagers.Navigations;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace EB.Persistence.SecurityManagers.RoleClaims;

public static class RoleClaimHelper
{
    public static async Task<List<string>> GetPermissionClaims(IMenuService menuService, List<string> roles)
    {
        var claims = new List<string>();
        var menuList = await NavigationBuilder
            .BuildFinalNavigations(menuService, roles);
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

    public static async Task AddAllClaimsToUser(UserManager<ApplicationUser> userManager, ApplicationUser user, IMenuService menuService)
    {
        foreach (var item in (await GetPermissionClaims(menuService, ["SuperAdmin"])))
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
