using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.ToList();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();

    private Menu(
        MenuId id,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        IEnumerable<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        _sections = sections.ToList();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        IEnumerable<MenuSection> sections)
    {
        Menu menu = new (
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
        menu.AddDomainEvent(new MenuCreated(menu));
        return menu;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Menu()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}