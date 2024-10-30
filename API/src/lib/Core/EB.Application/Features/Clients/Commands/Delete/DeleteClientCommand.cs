using MediatR;

namespace EB.Application.Features.Clients.Commands.Delete;

public record DeleteClientCommand(string id) : IRequest;