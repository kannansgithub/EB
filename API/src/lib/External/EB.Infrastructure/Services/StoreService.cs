using AutoMapper;
using EB.Application.Services.Repositories;
using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.Exceptions;
using EB.Domain.Services;
using EB.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace EB.Infrastructure.Services;

public class StoreService(
    IUnitOfWork _uow,
    IMapper _mapper,
    IDistributedCache _cache,
    ILogger<StoreService> _logger
) : IStoreService
{
    string cacheKey = "stores";
    public async Task<StoreResponse> CreateStoreAsync(StoreModel storeModel, CancellationToken token = default)
    {
        var addressEntity = _mapper.Map<Address>(storeModel);
        var storeEntity = _mapper.Map<Store>(storeModel);
        using var transaction = _uow.BeginTransaction();
        try
        {
            var address=await _uow.Addresses.AddAsync(addressEntity, token);
            storeEntity.AddressId=address.Id;
            var store = await _uow.Stores.AddAsync(storeEntity, token);
            await _uow.SaveAsync(token);
            transaction?.Commit();
            _cache.Remove(cacheKey);
            return new StoreResponse(
                    store.Id,
                    store.ClientId,
                    store.Code,
                    storeModel.Name,
                    storeModel.Description,
                    storeModel.AddressLine1,
                    storeModel.AddressLine2,
                    storeModel.AddressLine3,
                    storeModel.City,
                    storeModel.Region,
                    storeModel.PostalCode,
                    storeModel.Country,
                    storeModel.PhoneNumber,
                    storeModel.Fax
            ); ;
        }
        catch
        {
            transaction?.Rollback();
            throw;
        }
        finally
        {
            transaction?.Dispose();
        }
    }

    public async Task DeleteStoreAsync(string id, CancellationToken token = default)
    {
        using var transaction = _uow.BeginTransaction();
        try
        {
            var store = await _uow.Stores.GetByIdAsync(id, token);
            if (store is null) throw new NotFoundException(nameof(store), id);
            var address = await _uow.Addresses.GetByIdAsync(store.AddressId, token);
            if (address is not null) throw new DeleteOperationException(nameof(address), id);
            await _uow.Stores.DeleteAsync(store, token);
            await _uow.SaveAsync(token);
            transaction?.Commit();
            _cache.Remove(cacheKey);
            _cache.Remove($"{cacheKey}:{id}");
        }
        catch
        {
            transaction?.Rollback();
            throw;
        }
        finally
        {
            transaction?.Dispose();
        }
    }

    public async Task<StoreResponse?> GetStoreAsync(string id, CancellationToken token = default)
    {
        cacheKey += $":{id}";
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var store = await _cache.GetOrSetAsync(cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                var storeResult = await _uow.Stores.Get()
                    .Include(x => x.Address)
                    .Where(x => x.Id == id)
                    .ToListAsync();
                return storeResult.Select(s=>new StoreResponse(
                    s.Id,
                    s.ClientId,
                    s.Code,
                    s.Name,
                    s.Description,
                    s.Address?.AddressLine1,
                    s.Address?.AddressLine2,
                    s.Address?.AddressLine3,
                    s.Address?.City,
                    s.Address?.Region,
                    s.Address?.ZipCode,
                    s.Address?.Country,
                    s.Address?.Phone,
                    s.Address?.Fax
                    )).FirstOrDefault();
            })!;
        return store??default;
    }

    public async Task<IEnumerable<StoreResponse>?> GetStoresAsync(CancellationToken token = default)
    {
        _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
        var cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        var storesResult = await _cache.GetOrSetAsync(cacheKey,
            async () =>
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                var storeResult = await _uow.Stores.Get().Include(x => x.Address).ToListAsync();
                return storeResult.Select(s => new StoreResponse(
                    s.Id,
                    s.ClientId,
                    s.Code,
                    s.Name,
                    s.Description,
                    s.Address?.AddressLine1,
                    s.Address?.AddressLine2,
                    s.Address?.AddressLine3,
                    s.Address?.City,
                    s.Address?.Region,
                    s.Address?.ZipCode,
                    s.Address?.Country,
                    s.Address?.Phone,
                    s.Address?.Fax
                    ));
            }, cacheOptions)!;
        return storesResult;
    }

    public async Task<StoreResponse> UpdateStoreAsync(string id, StoreModel storeModel, CancellationToken token = default)
    {
        using var transaction = _uow.BeginTransaction();
        try
        {
            var store = await _uow.Stores.GetByIdAsync(id, token);
            if (store is null) throw new NotFoundException(nameof(store), id);
            var address = await _uow.Addresses.GetByIdAsync(store.AddressId, token);
            if (address is not null)
            {
                await _uow.Addresses.UpdateAsync(address, token);
            }
            await _uow.Stores.UpdateAsync(store, token);
            await _uow.SaveAsync(token);
            transaction?.Commit();
            _cache.Remove(cacheKey);
            _cache.Remove($"{cacheKey}:{id}");
            return new StoreResponse(
                    id,
                    store.ClientId,
                    store.Code,
                    storeModel.Name,
                    storeModel.Description,
                    storeModel.AddressLine1,
                    storeModel.AddressLine2,
                    storeModel.AddressLine3,
                    storeModel.City,
                    storeModel.Region,
                    storeModel.PostalCode,
                    storeModel.Country,
                    storeModel.PhoneNumber,
                    storeModel.Fax
            );
        }
        catch
        {
            transaction?.Rollback();
            throw;
        }
        finally
        {
            transaction?.Dispose();
        }
    }
}
