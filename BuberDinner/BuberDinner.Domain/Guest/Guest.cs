using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _guestRatings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.ToList();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();
    public IReadOnlyList<BillId> BillIds => _billIds.ToList();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();
    public IReadOnlyList<GuestRating> Ratings => _guestRatings.ToList();

    private Guest(
        GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}