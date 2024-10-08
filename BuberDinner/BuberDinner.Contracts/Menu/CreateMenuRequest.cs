namespace BuberDinner.Contracts.Menu;

public record CreateMenuRequest(
    string Name,
    string Description,
    IEnumerable<MenuSection> Sections);

public record MenuSection(
    string Name,
    string Description,
    IEnumerable<MenuItem> Items);

public record MenuItem(
    string Name,
    string Description);