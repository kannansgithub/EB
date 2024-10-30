using EB.Domain.Repositories;
using EB.Domain.Shared;
using MediatR;

namespace EB.Application.Products.Commands.Create;

internal sealed class CreateProductCommandHandler(IProductRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //var product = new Product(
        //    new PrimarytId(Guid.NewGuid().ToString("N")),
        //    request.Name,
        //    new Money(request.Currency, request.Amount),
        //    Sku.Create(request.Sku)!);
        //await _repository.AddAsync(product, cancellationToken);
        //await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
