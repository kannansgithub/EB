using AutoMapper;
using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.Exceptions;
using EB.Domain.Services;
using EB.Domain.Shared;
using EB.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace EB.Infrastructure.Services;

public class ClientService(
    IUnitOfWork _uow,
    IMapper _mapper,
    IDistributedCache _cache,
    ILogger<ClientService> _logger
) : IClientService
{
    string cacheKey = "clients";

    public async Task<ClientModel> CreateClientAsync(ClientRequest clientModel, CancellationToken token = default)
    {
        var entity = _mapper.Map<Client>(clientModel);
        var client = await _uow.Clients.AddAsync(entity, token);
        await _uow.SaveChangesAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        return _mapper.Map<ClientModel>(client);
    }

    public async Task DeleteClientAsync(string id, CancellationToken token = default)
    {
        var client=await GetClientAsync(id, token);
        if(client is null) throw new NotFoundException(nameof(client), id);
        await _uow.Clients.DeleteAsync(_mapper.Map<Client>(client), token);
        await _uow.SaveChangesAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        _cache.Remove($"{cacheKey}:{id}");
    }

    public async Task<ClientModel?> GetClientAsync(string Id, CancellationToken token = default)
    {
        cacheKey += $":{Id}";
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var client = await _cache.GetOrSetAsync(cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                return await _uow.Clients.GetByIdAsync(Id, token);
            })!;
        return _mapper.Map<ClientModel>(client);
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync(CancellationToken token = default)
    {
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        var clients = await _cache.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                return await _uow.Clients.GetAllAsync(token);
            },
            cacheOptions)!;
        return _mapper.Map<List<ClientModel>>(clients);
    }

    public async Task<ClientModel> UpdateClientAsync(string id,ClientRequest clientModel, CancellationToken token = default)
    {
        var entity = _mapper.Map<Client>(clientModel);
        entity.Id = id;
        var client = await _uow.Clients.UpdateAsync(entity, token);
        await _uow.SaveChangesAsync(token);
        _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        _cache.Remove(cacheKey);
        _cache.Remove($"{cacheKey}:{id}");
        return _mapper.Map<ClientModel>(client);
    }
}
