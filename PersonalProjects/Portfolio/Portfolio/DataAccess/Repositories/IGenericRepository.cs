using System.Linq.Expressions;

namespace Portfolio.DataAccess.Repositories;
public interface IGenericRepository<Tentity> where Tentity : class, new()
{
    Task<List<Tentity>> GetAllAsync();
    Task<Tentity?> GetAsync(int id);
    Task<Tentity?> GetByFilterAsync(Expression<Func<Tentity,bool>> filter);
    Task CreateAsync(Tentity tentity);
    Task UpdateAsync(Tentity tentity);
    Task DeleteAsync(Tentity tentity);
}
