using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using EB.Domain.Repositories;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EB.Persistence.SecurityManagers.Navigations;

public class NavigationService(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IRoleClaimService roleClaimService,
    IMenuRepository menuRepository
        ) : INavigationService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly IRoleClaimService _roleClaimService = roleClaimService;
    private readonly IMenuRepository _menuRepository = menuRepository;

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
        var finalNavigations =await NavigationBuilder.BuildFinalNavigations(_menuRepository, roles);
        int parentIndex = 1;
        foreach (var navigation in finalNavigations)
        {
            var parentNav = new NavigationItem(
                navigation.Name,
                navigation.Caption,
                navigation.URI,
                navigation.Icon
                )
            {
                ParentIndex = 0,
                Index = parentIndex
            };
            int childIndex = 1;
            foreach (var child in navigation.Children)
            {
                var isAuthorized = CheckAuthorization(claims, child.Name);

                parentNav.AddChild(new NavigationItem(
                    child.Name,
                    child.Caption,
                    child.URI,
                    navigation.Icon,
                    isAuthorized
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
                item => new MainNavDto(item.Name, item.Caption, item.Url, item.IsAuthorized, item.Index, item.ParentIndex),
                item => item.Children,
                (parent, children) => parent.Children = children
            );

        cancellationToken.ThrowIfCancellationRequested();
        return new GetMainNavResult { MainNavigations = results };
    }
}
