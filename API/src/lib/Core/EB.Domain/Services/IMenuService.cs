using EB.Domain.Abstrations;

namespace EB.Domain.Services;

public interface IMenuService
{
    public Task<ICollection<MenuModel>> GetAllAsync(List<string> roles, CancellationToken token = default);
    public Task<MenuModel> CreateMenuAsync(MenuRequest menuModel, CancellationToken token = default);
    public Task<MenuModel> UpdateMenuAsync(string id, MenuRequest menuModel, CancellationToken token = default);
    public Task DeleteMenuAsync(string id, CancellationToken token = default);
    public Task<MenuModel?> GetMenuAsync(string id, CancellationToken token = default);
    public Task<IEnumerable<MenuModel>> GetMenusAsync(CancellationToken token = default);
}
