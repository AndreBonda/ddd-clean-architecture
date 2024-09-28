using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public string Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyCollection<Reservation> Reservations => _reservations.ToList();

    private Dinner(
        DinnerId id,
        string name,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime
        )
        : base(id)
    {
        Name = name;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Dinner()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}