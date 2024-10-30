using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Clients.Commands.Update;
public record UpdateClientCommand(string id, ClientRequest model) : IRequest<ClientModel>;

