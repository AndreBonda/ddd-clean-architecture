using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task AddMenuAsync(Menu menu);
    Task<Menu> GetByIdAsync(MenuId id);
}