using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    string HostId,
    IEnumerable<MenuSectionCommand> Sections)
    : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    IEnumerable<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);