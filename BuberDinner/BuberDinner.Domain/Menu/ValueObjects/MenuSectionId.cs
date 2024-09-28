using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; private set; }

    public MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid id)
    {
        return new(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuSectionId()
    {

    }

}