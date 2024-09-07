namespace BuberDinner.Contracts.Menu;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    double? AverageRating,
    string HostId,
    IEnumerable<MenuSectionResponse> Sections,
    IEnumerable<string> DinnerIds,
    IEnumerable<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    IEnumerable<MenuItemResponse> Items);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description);