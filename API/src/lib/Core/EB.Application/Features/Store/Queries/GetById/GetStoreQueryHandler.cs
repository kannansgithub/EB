using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Store.Queries.GetById;

internal sealed class GetStoreQueryHandler(IStoreService service) : IRequestHandler<GetStoreQuery, StoreResponse?>
{
    public async Task<StoreResponse?> Handle(GetStoreQuery request, CancellationToken cancellationToken)
    {
        return await service.GetStoreAsync(request.id, cancellationToken);
    }
}
