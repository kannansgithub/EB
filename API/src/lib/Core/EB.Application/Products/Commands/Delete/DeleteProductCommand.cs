using MediatR;

namespace EB.Application.Products.Commands.Delete;

public record DeleteProductCommand(string ProductId):IRequest;
