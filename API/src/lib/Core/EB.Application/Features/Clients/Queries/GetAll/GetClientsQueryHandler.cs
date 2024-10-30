using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Clients.Queries.GetAll;

internal sealed class GetClientsQueryHandler(IClientService service) : IRequestHandler<GetClientsQuery, IEnumerable<ClientModel>>
{
    public async Task<IEnumerable<ClientModel>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return await service.GetClientsAsync(cancellationToken);
    }
}
