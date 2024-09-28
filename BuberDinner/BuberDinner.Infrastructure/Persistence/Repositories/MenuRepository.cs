using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository(BuberDinnerDbContext ctx) : IMenuRepository
{
    public async Task AddMenuAsync(Menu menu)
    {
        await ctx.AddAsync(menu);
        await ctx.SaveChangesAsync();
    }

    public Task<Menu> GetByIdAsync(MenuId id)
    {
        throw new NotImplementedException();
    }
}