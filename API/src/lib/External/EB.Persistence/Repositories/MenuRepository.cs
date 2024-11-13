using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class MenuRepository(DataContext dbContext) : GenericRepository<Menu>(dbContext), IMenuRepository
{
    private new readonly DataContext _dbContext = dbContext;

    public async Task<ICollection<Menu>> GetAllAsync(List<string> roles, CancellationToken token = default)
    {
        var menus = _dbContext.Menu
                            .Where(x=>x.IsDeleted==false)
                            .Include(menu => menu.Sub) // Eagerly load children
                            .AsQueryable();
        var filteredMenus = await GetMenusWithMatchingRolesAsync(menus, roles, token);
        return filteredMenus;
    }
    private static async Task<ICollection<Menu>> GetMenusWithMatchingRolesAsync(IQueryable<Menu> menus, List<string> rolesToFilter, CancellationToken token)
    {
        // Recursive function to filter the Menu and its children asynchronously
        async Task<List<Menu>> FilterMenusAsync(IEnumerable<Menu> menuList, CancellationToken token=default)
        {
            var result = new List<Menu>();

            foreach (var menu in menuList)
            {
                // Check if any of the roles of the current Menu match the roles to filter
                if (!result.Any(x=>x.Name==menu.Name) && menu.Roles.Any(role => rolesToFilter.Contains(role)))
                {
                    result.Add(menu);
                }

                // Recursively check the children
                if (menu.Sub.Count != 0)
                {
                    var filteredChildren = await FilterMenusAsync(menu.Sub, token); // Recursive call to get filtered children asynchronously
                    result.AddRange(filteredChildren);
                }
            }

            return result;
        }

        // Start filtering from the root menu list asynchronously
        return await FilterMenusAsync(await menus.ToListAsync(token), token);
    }
}
