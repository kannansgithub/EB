using EB.Domain.Abstrations;
using EB.Domain.Exceptions;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Client.Queries.GetById
{
    internal sealed class GetClientQueryHandler(IClientService clientService) : IRequestHandler<GetClientQuery, ClientModel>
    {
        public async Task<ClientModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await clientService.GetClientAsync(request.id, cancellationToken);
            if (client is null) throw new NotFoundException(nameof(client), request.id);
            return client;
        }
    }
}
