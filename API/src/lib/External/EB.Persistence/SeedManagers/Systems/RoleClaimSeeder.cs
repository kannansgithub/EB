
using EB.Application.Services.CQS;
using EB.Domain.Entities;
using EB.Persistence.SecurityManagers.Navigations;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;

namespace EB.Persistence.SeedManagers.Systems;

public class RoleClaimSeeder(RoleManager<IdentityRole> roleManager)
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task GenerateDataAsync()
    {
        var superAdminRole = "SuperAdmin";
        if (!await _roleManager.RoleExistsAsync(superAdminRole))
        {
            await _roleManager.CreateAsync(new IdentityRole(superAdminRole));
            var role = await _roleManager.FindByNameAsync(superAdminRole);
            if (role != null)
            {
                var claims=GetAccess();
                foreach (var claim in claims)
                {
                    await _roleManager.AddClaimAsync(role, claim);
                }
                //foreach (var item in NavigationBuilder
                //    .BuildFinalNavigations()
                //    .SelectMany(x => x.Children))
                //{
                //    await _roleManager.AddClaimAsync(role, new Claim("Permission", $"{item.Name}:Create"));
                //    await _roleManager.AddClaimAsync(role, new Claim("Permission", $"{item.Name}:Read"));
                //    await _roleManager.AddClaimAsync(role, new Claim("Permission", $"{item.Name}:Update"));
                //    await _roleManager.AddClaimAsync(role, new Claim("Permission", $"{item.Name}:Delete"));
                //}

            }
        }
        var adminRole = "Admin";
        if (!await _roleManager.RoleExistsAsync(adminRole))
        {
            await _roleManager.CreateAsync(new IdentityRole(adminRole));
            var role = await _roleManager.FindByNameAsync(adminRole);
            if (role != null)
            {
                var claims = GetAccess();
                foreach (var claim in claims)
                {
                    await _roleManager.AddClaimAsync(role, claim);
                }
            }
        }
        var basicRole = "Basic";
        if (!await _roleManager.RoleExistsAsync(basicRole))
        {
            await _roleManager.CreateAsync(new IdentityRole(basicRole));
            var role = await _roleManager.FindByNameAsync(basicRole);
            if (role != null)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", $"UserProfile:Create"));
                await _roleManager.AddClaimAsync(role, new Claim("Permission", $"UserProfile:Read"));
                await _roleManager.AddClaimAsync(role, new Claim("Permission", $"UserProfile:Update"));
                await _roleManager.AddClaimAsync(role, new Claim("Permission", $"UserProfile:Delete"));
            }
        }
    }

    private Claim GetAccess(string entity, string access)
    {
        return new Claim("Permission", $"{entity}:{access}");
    }
    private static PropertyInfo[] GetAllEntity()
    {
        Type entityType = typeof(IEntityDbSet);
        PropertyInfo[] properties = entityType.GetProperties();

        return properties;
    }
    private List<Claim> GetAccess(bool IsReadOnly=false)
    {
        var properties = GetAllEntity()?.ToList();
        List<Claim> claims = [];
        if (properties is null) return claims; 
        foreach (var item in properties)
        {
            claims.Add(GetAccess(item.Name, "Read"));
            if (!IsReadOnly)
            {
                claims.Add(GetAccess(item.Name, "Create"));
                claims.Add(GetAccess(item.Name, "Update"));
                claims.Add(GetAccess(item.Name, "Delete"));
            }
        }

        return claims;
    }
}

