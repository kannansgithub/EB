using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Client.Commands.Update;
public record UpdateClientCommand(string id, ClientRequest model) : IRequest<ClientModel>;

