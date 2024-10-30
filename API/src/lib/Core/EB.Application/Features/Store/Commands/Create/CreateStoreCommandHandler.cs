using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Store.Commands.Create;

internal sealed class CreateStoreCommandHandler(IStoreService service) : IRequestHandler<CreateStoreCommand, StoreResponse>
{
    public async Task<StoreResponse> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        return await service.CreateStoreAsync(request.model, cancellationToken); ;
    }
}
