using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Clients.Queries.GetAll;

public record GetClientsQuery() : IRequest<IEnumerable<ClientModel>>;
