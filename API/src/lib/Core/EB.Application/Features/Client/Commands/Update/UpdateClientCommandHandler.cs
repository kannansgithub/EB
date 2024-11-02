using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Client.Commands.Update;

internal sealed class UpdateClientCommandHandler(IClientService service) : IRequestHandler<UpdateClientCommand, ClientModel>
{
    public async Task<ClientModel> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        return await service.UpdateClientAsync(request.id, request.model, cancellationToken);
    }
}
