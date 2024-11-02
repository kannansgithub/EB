using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Client.Commands.Delete;

internal sealed class DeleteClientCommandHandler(IClientService service) : IRequestHandler<DeleteClientCommand>
{
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        await service.DeleteClientAsync(request.id, cancellationToken);
    }
}
