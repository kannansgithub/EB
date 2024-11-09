using EB.Domain.Abstrations;
using MediatR;

namespace EB.Application.Features.Menus.Commands.Create;

public record CreateMenuCommand(MenuRequest model) : IRequest<MenuModel>;
