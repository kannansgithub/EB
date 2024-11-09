using EB.Domain.Abstrations;
using EB.Domain.Services;
using MediatR;

namespace EB.Application.Features.Menus.Commands.Create;

internal sealed class CreateMenuCommandHandler(IMenuService service) : IRequestHandler<CreateMenuCommand, MenuModel>
{
    public async Task<MenuModel> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        return await service.CreateMenuAsync(request.model, cancellationToken);
    }
}
