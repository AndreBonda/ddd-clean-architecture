using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Mappings;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        Menu menu = command.ToMenu();
        await menuRepository.AddMenuAsync(menu);
        return menu;
    }
}