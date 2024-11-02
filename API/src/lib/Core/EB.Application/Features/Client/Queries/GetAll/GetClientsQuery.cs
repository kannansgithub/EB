using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Client.Queries.GetAll;

public record GetClientsQuery() : IRequest<IEnumerable<ClientModel>>;
