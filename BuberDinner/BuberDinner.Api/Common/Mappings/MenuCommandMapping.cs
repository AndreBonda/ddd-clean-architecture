using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Api.Common.Mappings;

public static class MenuMappings
{
    public static CreateMenuCommand ToCommand(this CreateMenuRequest request, string hostId)
    {
        CreateMenuCommand command = new(
            request.Name,
            request.Description,
            hostId,
            request.Sections.Select(section =>
                new MenuSectionCommand(
                    section.Name,
                    section.Description,
                    section.Items.Select(item => new MenuItemCommand(item.Name, item.Description)))));

        return command;
    }

    public static MenuResponse ToResponse(this Menu menu)
    {
        return new MenuResponse(
            menu.Id.Value.ToString(),
            menu.Name,
            menu.Description,
            menu.AverageRating.Value,
            menu.HostId.Value.ToString(),
            menu.Sections.Select(s => new MenuSectionResponse(
                s.Id.Value.ToString(),
                s.Name,
                s.Description,
                s.Items.Select(
                    item => new MenuItemResponse(
                        item.Id.Value.ToString(),
                        item.Name,
                        item.Description)))),
            menu.DinnerIds.Select(id => id.Value.ToString()),
            menu.MenuReviewIds.Select(id => id.Value.ToString()),
            menu.CreatedDateTime,
            menu.UpdatedDateTime
        );
    }
}