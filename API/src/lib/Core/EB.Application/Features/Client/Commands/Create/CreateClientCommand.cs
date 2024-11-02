using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Client.Commands.Create;

public record CreateClientCommand(ClientRequest model) : IRequest<ClientModel>;

