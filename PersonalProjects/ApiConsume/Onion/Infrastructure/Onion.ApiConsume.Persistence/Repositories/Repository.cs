using Microsoft.EntityFrameworkCore;
using Onion.ApiConsume.Application.Interfaces;
using Onion.ApiConsume.Persistence.Context;
using System.Linq.Expressions;

namespace Onion.ApiConsume.Persistence.Repositories;
public class Repository<T> : IRepository<T> where T : class, new()
{
    private readonly BaseContext _context;
    public Repository(BaseContext context) => _context = context;

    public async Task CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().FindAsync(filter);
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
