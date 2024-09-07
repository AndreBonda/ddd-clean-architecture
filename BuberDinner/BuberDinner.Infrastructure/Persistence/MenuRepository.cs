using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly List<Menu> _menus = new();
    public async Task AddMenuAsync(Menu menu)
    {
        await Task.CompletedTask;
        _menus.Add(menu);
    }

    public Task<Menu> GetByIdAsync(MenuId id)
    {
        throw new NotImplementedException();
    }
}