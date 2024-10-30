using EB.Domain.Shared;
using MediatR;

namespace EB.Application.Products.Queries.GetAll
{
    internal sealed class GetProductAllQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetProductAllQuery, IEnumerable<ProductResponse>>
    {
        public async Task<IEnumerable<ProductResponse>> Handle(GetProductAllQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);
            var productList = products.Select(p => new ProductResponse(p.Id.value, p.Name, p.Sku.Value, p.Price.Currency, p.Price.Amount));
            return productList;
        }
    }
}
