using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Client.Queries.GetById;

public record GetClientQuery(string id) : IRequest<ClientModel>;

