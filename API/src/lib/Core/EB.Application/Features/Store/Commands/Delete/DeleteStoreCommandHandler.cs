using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Store.Commands.Delete;

internal sealed class DeleteStoreCommandHandler(IStoreService service) : IRequestHandler<DeleteStoreCommand>
{
    public async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        await service.DeleteStoreAsync(request.id, cancellationToken);
    }
}
