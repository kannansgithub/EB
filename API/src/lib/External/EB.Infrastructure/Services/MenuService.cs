using AutoMapper;
using EB.Application.Services.Repositories;
using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.Exceptions;
using EB.Domain.Services;
using EB.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace EB.Infrastructure.Services;

public class MenuService(
    IUnitOfWork _uow,
    IMapper _mapper,
    IDistributedCache _cache,
    ILogger<MenuService> _logger
) : IMenuService
{
    string cacheKey = "menus";

    public async Task<MenuModel> CreateMenuAsync(MenuRequest menuModel, CancellationToken token = default)
    {
        var entity = _mapper.Map<Menu>(menuModel);
        var client = await _uow.Menus.AddAsync(entity, token);
        await _uow.SaveAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        return _mapper.Map<MenuModel>(client);
    }

    public async Task DeleteMenuAsync(string id, CancellationToken token = default)
    {
        var menu = await GetMenuAsync(id, token);
        if (menu is null) throw new NotFoundException(nameof(menu), id);
        await _uow.Menus.DeleteAsync(_mapper.Map<Menu>(menu), token);
        await _uow.SaveAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        _cache.Remove($"{cacheKey}:{id}");
    }

    public async Task<ICollection<MenuModel>> GetAllAsync(List<string> roles, CancellationToken token = default)
    {
        cacheKey += $":{string.Join(":", roles)}";
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var menus = await _cache.GetOrSetAsync(cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                return await _uow.Menus.GetAllAsync(roles, token);
            })!;
        return _mapper.Map<List<MenuModel>>(menus);
    }

    public async Task<MenuModel?> GetMenuAsync(string id, CancellationToken token = default)
    {
        cacheKey += $":{id}";
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var menus = await _cache.GetOrSetAsync(cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                return await _uow.Menus.GetByIdAsync(id, token);
            })!;
        return _mapper.Map<MenuModel>(menus);
    }

    public async Task<IEnumerable<MenuModel>> GetMenusAsync(CancellationToken token = default)
    {
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        var menus = await _cache.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                return await _uow.Menus.GetAllAsync(token);
            },
            cacheOptions)!;
        return _mapper.Map<List<MenuModel>>(menus);
    }

    public async Task<MenuModel> UpdateMenuAsync(string id, MenuRequest menuModel, CancellationToken token = default)
    {
        var existingMenu = await GetMenuAsync(id, token) ?? throw new NotFoundException(nameof(Menu), id);
        var entity = _mapper.Map<Menu>(menuModel);
        entity.Id = id;
        var menu = await _uow.Menus.UpdateAsync(entity, token);
        await _uow.SaveAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        _cache.Remove($"{cacheKey}:{id}");
        return _mapper.Map<MenuModel>(menu);
    }
}
