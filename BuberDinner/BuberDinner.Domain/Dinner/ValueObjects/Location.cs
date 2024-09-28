using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    private Location(
        string name,
        string description,
        double latitude,
        double longitude)
    {
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(string name, string description, double latitude, double longitude)
    {
        return new(name, description, latitude, longitude);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Description;
        yield return Latitude;
        yield return Longitude;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Location()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}