using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Store.Commands.Update;

public record UpdateStoreCommand(string id, StoreModel model) : IRequest<StoreResponse>;
