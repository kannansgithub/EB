using EB.Domain.Abstrations;

namespace EB.Domain.Services;

public interface IStoreService
{
    public Task<StoreResponse> CreateStoreAsync(StoreModel storeModel, CancellationToken token = default);
    public Task<StoreResponse> UpdateStoreAsync(string id, StoreModel storeModel, CancellationToken token = default);
    public Task DeleteStoreAsync(string id, CancellationToken token = default);
    public Task<StoreResponse?> GetStoreAsync(string id, CancellationToken token = default);
    public Task<IEnumerable<StoreResponse>?> GetStoresAsync(CancellationToken token = default);
}
