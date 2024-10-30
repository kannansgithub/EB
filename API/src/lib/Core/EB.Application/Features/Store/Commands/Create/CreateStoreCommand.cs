using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Store.Commands.Create;

public record CreateStoreCommand(StoreModel model) : IRequest<StoreResponse>;
