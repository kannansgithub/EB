using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Store.Queries.GetById;

public record GetStoreQuery(string id) : IRequest<StoreResponse?>;
