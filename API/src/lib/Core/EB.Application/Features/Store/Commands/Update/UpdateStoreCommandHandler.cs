using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Store.Commands.Update;

internal sealed class UpdateStoreCommandHandler(IStoreService service) : IRequestHandler<UpdateStoreCommand, StoreResponse>
{
    public async Task<StoreResponse> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        return await service.UpdateStoreAsync(request.id, request.model, cancellationToken);
    }
}
