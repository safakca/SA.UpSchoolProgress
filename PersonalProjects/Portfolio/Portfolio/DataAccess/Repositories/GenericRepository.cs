using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Context;
using System.Linq.Expressions;

namespace Portfolio.DataAccess.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly BaseContext _context; 
    public GenericRepository(BaseContext context) => _context = context; 
  
    /// <summary>
    /// GETALL
    /// </summary>
    /// <returns></returns>
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// GET
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    /// <summary>
    /// GET BY FILTER
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(filter);
    }

    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="tentity"></param>
    /// <returns></returns>
    public async Task CreateAsync(TEntity tentity)
    {
        await _context.Set<TEntity>().AddAsync(tentity);
        await _context.SaveChangesAsync();
    } 

    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="tentity"></param>
    /// <returns></returns>
    public async Task UpdateAsync(TEntity tentity)
    {
         _context.Set<TEntity>().Update(tentity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// REMOVE
    /// </summary>
    /// <param name="tentity"></param>
    /// <returns></returns>
    public async Task DeleteAsync(TEntity tentity)
    {
        _context.Set<TEntity>().Remove(tentity);
        await _context.SaveChangesAsync();
    }
}
