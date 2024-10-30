using EB.Domain.Exceptions;
using EB.Domain.Repositories;
using EB.Domain.Shared;
using MediatR;

namespace EB.Application.Products.Commands.Delete;

internal sealed class DeleteProductCommandHandler(IProductRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product=await _repository.GetByIdAsync(request.PrimarytId.value, cancellationToken) ?? throw new ProductNotFoundException(request.PrimarytId);
        await _repository.DeleteAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
