using MediatR;

namespace EB.Application.Products.Commands.Create
{
    public record CreateProductCommand(
        string Name,
        string Sku,
        string Currency,
        decimal Amount) : IRequest
    {
    }
}
