using MediatR;

namespace EB.Application.Features.Client.Commands.Delete;

public record DeleteClientCommand(string id) : IRequest;