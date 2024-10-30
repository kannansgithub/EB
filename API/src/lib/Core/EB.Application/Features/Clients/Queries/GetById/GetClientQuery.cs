using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Clients.Queries.GetById;

public record GetClientQuery(string id) : IRequest<ClientModel>;

