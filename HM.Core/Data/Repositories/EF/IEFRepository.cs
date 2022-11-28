using HM.Core.Data.Models;
using System.Linq.Expressions;

namespace HM.Core.Data.Repositories.EF;
public interface IEFRepository<TEntity>
   where TEntity : class, IEntity, new()
{
    TEntity Get(int id);
    Task<TEntity> GetAsync(int id);

    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllIncluding<TProperty>(params Expression<Func<TEntity, TProperty>>[] propertySelectors);
    List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
    List<TEntity> GetAllList();
    Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAllListAsync();
    IQueryable<TEntity> GetAllAsNoTracking();

    TEntity Add(TEntity entity);
    int AddAndGetId(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity);
    Task<int> AddAndGetIdAsync(TEntity entity);
    List<TEntity> AddRange(List<TEntity> entity);
    Task<List<TEntity>> AddRangeAsync(List<TEntity> entity);

    TEntity Update(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);

    void Delete(TEntity entity);
    void Delete(int id);
    void Delete(Expression<Func<TEntity, bool>> predicate);
    Task DeleteAsync(int id);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    Task DeleteAsync(TEntity entity);

    TEntity Single(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}
