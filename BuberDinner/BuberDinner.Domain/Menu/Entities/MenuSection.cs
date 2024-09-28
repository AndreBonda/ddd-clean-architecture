using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.ToList();

    private MenuSection(
        MenuSectionId id,
        string name,
        string description,
        IEnumerable<MenuItem> items)
        : base(id)
    {
        Name = name;
        Description = description;
        _items = items.ToList();
    }

    public static MenuSection Create(
        string name,
        string description,
        IEnumerable<MenuItem> items)
    {
        return new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private MenuSection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}