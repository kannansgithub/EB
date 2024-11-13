using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using EB.Domain.Services;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EB.Persistence.SecurityManagers.Navigations;

public class NavigationService(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IRoleClaimService roleClaimService,
    IMenuService menuService
        ) : INavigationService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly IRoleClaimService _roleClaimService = roleClaimService;
    private readonly IMenuService _menuService = menuService;

    private static List<TDestination> MapResult<TSource, TDestination>(
            List<TSource> sourceItems,
            Func<TSource, TDestination> mapFunc,
            Func<TSource, IEnumerable<TSource>> getChildrenFunc,
            Action<TDestination, List<TDestination>> setChildrenAction
        )
    {
        return sourceItems.Select(item =>
        {
            var result = mapFunc(item);
            var children = getChildrenFunc(item).Select(child => mapFunc(child)).ToList();
            setChildrenAction(result, children);
            return result;
        }).ToList();
    }

    private static bool CheckAuthorization(IEnumerable<Claim> claims, string navigationName)
    {
        var requiredPermissions = new List<string>
        {
            $"{navigationName}:Create",
            $"{navigationName}:Read",
            $"{navigationName}:Update",
            $"{navigationName}:Delete"
        };

        return claims.Any(c => requiredPermissions.Contains(c.Value));
    }


    private async Task<List<NavigationItem>> BuildMainNav(string userId)
    {
        var navItems = new List<NavigationItem>();
        var claims = await _roleClaimService.GetClaimListByUserAsync(userId);
        var roles = await _roleClaimService.GetRoleListByUserAsync(userId);
        var finalNavigations =await NavigationBuilder.BuildFinalNavigations(_menuService, roles);
        int parentIndex = 1;
        foreach (var navigation in finalNavigations)
        {
            var parentNav = new NavigationItem(
                navigation.Name,
                navigation.Caption,
                navigation.URI,
                navigation.Label,
                navigation.Icon,
                hasReadAccess:navigation.HasReadAccess,
                hasWriteAccess:navigation.HasWriteAccess,
                hasUpdateAccess:navigation.HasUpdateAccess,
                hasDeleteAccess:navigation.HasDeleteAccess
                )
            {
                ParentIndex = 0,
                Index = parentIndex
            };
            int childIndex = 1;
            foreach (var child in navigation.Sub)
            {
                var isAuthorized = CheckAuthorization(claims, child.Name);

                parentNav.AddChild(new NavigationItem(
                    child.Name,
                    child.Caption,
                    child.URI,
                    child.Label,
                    child.Icon,
                    isAuthorized,
                    hasReadAccess: child.HasReadAccess,
                    hasWriteAccess: child.HasWriteAccess,
                    hasUpdateAccess: child.HasUpdateAccess,
                    hasDeleteAccess: child.HasDeleteAccess
                    )
                {
                    ParentIndex = parentIndex,
                    Index = childIndex
                });

                childIndex++;
            }

            parentNav.IsAuthorized = parentNav.Children.Any(x => x.IsAuthorized);
            navItems.Add(parentNav);

            parentIndex++;
        }

        return navItems;
    }




    public async Task<GetMainNavResult> GenerateMainNavAsync(string userId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var user = await _userManager.FindByIdAsync(userId) ?? throw new NavigationException($"Invalid userid: {userId}");
        var navItems = await BuildMainNav(user.Id);

        var results = MapResult(
                navItems,
                item => new MainNavDto(item.Name, item.Caption, item.Url,item.Label??string.Empty, item.Icon?? "BiMessageSquareError", item.IsAuthorized, item.Index, item.ParentIndex, item.HasReadAccess, item.HasUpdateAccess, item.HasWriteAccess, item.HasDeleteAccess),
                item => item.Children,
                (parent, children) => parent.Sub = children
            );

        cancellationToken.ThrowIfCancellationRequested();
        return new GetMainNavResult { MainNavigations = results };
    }
}
