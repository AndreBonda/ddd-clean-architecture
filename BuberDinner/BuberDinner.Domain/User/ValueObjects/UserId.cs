using System.Drawing;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set;  }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private UserId()
    {

    }
}