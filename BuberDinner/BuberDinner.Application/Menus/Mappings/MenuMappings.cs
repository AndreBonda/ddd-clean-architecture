using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Application.Menus.Mappings;

public static class MenuMappings
{
    public static Menu ToMenu(this CreateMenuCommand command)
    {
        return Menu.Create(
            command.Name,
            command.Description,
            AverageRating.Create(),
            HostId.Create(Guid.Parse(command.HostId)),
            command.Sections.Select(s =>
                MenuSection.Create(
                    s.Name,
                    s.Description,
                    s.Items.Select(i =>
                        MenuItem.Create(i.Name, i.Description))))
        );
    }
}