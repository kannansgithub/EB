using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Clients.Commands.Create;

public record CreateClientCommand(ClientRequest model) : IRequest<ClientModel>;

