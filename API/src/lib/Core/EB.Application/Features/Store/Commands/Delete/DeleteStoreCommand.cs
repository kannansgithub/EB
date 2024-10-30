using MediatR;

namespace EB.Application.Features.Store.Commands.Delete;

public record DeleteStoreCommand(string id) : IRequest;
