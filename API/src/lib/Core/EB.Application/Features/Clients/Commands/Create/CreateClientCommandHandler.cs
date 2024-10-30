using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Clients.Commands.Create;

internal sealed class CreateClientCommandHandler(IClientService service) : IRequestHandler<CreateClientCommand, ClientModel>
{
    public async Task<ClientModel> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        return await service.CreateClientAsync(request.model, cancellationToken);
    }
}
