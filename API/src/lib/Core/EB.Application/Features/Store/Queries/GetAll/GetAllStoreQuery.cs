using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Store.Queries.GetAll;

public record GetAllStoreQuery() : IRequest<IEnumerable<StoreResponse>?>;
