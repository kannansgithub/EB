using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Store.Queries.GetAll;

internal sealed class GetAllStoreQueryHandler(IStoreService service) : IRequestHandler<GetAllStoreQuery, IEnumerable<StoreResponse>?>
{
    public async Task<IEnumerable<StoreResponse>?> Handle(GetAllStoreQuery request, CancellationToken cancellationToken)
    {
        return await service.GetStoresAsync(cancellationToken);
    }
}
