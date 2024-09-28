using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; private set; }

    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid id)
    {
        return new(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuItemId()
    {
    }
}