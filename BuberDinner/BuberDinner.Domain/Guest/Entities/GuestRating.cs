using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public Rating Rating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating(
        GuestRatingId id,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating
        )
    {
        return new(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GuestRating()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}