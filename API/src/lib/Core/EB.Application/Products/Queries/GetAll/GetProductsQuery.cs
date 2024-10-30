using MediatR;

namespace EB.Application.Products.Queries.GetAll;

public record GetProductAllQuery():IRequest<IEnumerable<ProductResponse>>;

public record ProductResponse(string Id, string Name,string Sku, string Currency, decimal Amount);