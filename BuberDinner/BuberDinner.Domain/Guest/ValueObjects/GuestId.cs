using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; private set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private GuestId()
    {

    }
}