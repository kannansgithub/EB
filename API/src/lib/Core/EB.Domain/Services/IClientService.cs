using EB.Domain.Abstrations;

namespace EB.Domain.Services;

public interface IClientService
{
    public Task<ClientModel> CreateClientAsync(ClientRequest clientModel, CancellationToken token = default);
    public Task<ClientModel> UpdateClientAsync(string id,ClientRequest clientModel, CancellationToken token = default);
    public Task DeleteClientAsync(string id, CancellationToken token = default);
    public Task<ClientModel?> GetClientAsync(string id, CancellationToken token = default);
    public Task<IEnumerable<ClientModel>> GetClientsAsync(CancellationToken token= default);
}
