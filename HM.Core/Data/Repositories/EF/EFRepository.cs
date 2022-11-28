using HM.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HM.Core.Data.Repositories.EF;
public class EFRepository<TEntity> : IEFRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly DbContext _context;
    public EFRepository(DbContext context)
    {
        _dbSet = context.Set<TEntity>();
        _context = context;
    }

    #region Get Section
    public IQueryable<TEntity> GetAll()
    {
        var query = _dbSet.AsQueryable();
        return query;
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        var query = _dbSet.AsNoTracking();
        return query;
    }

    public List<TEntity> GetAllList()
    {
        var result = _dbSet.ToList();
        return result.ToList();
    }

    public async Task<List<TEntity>> GetAllListAsync()
    {
        var result = await _dbSet.AsQueryable().ToListAsync();
        return result;
    }

    public TEntity Get(int id)
    {
        var entity = _dbSet.FirstOrDefault(x => x.Id == id);
        return entity;
    }

    public async Task<TEntity> GetAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public IQueryable<TEntity> GetAllIncluding<TProperty>(params Expression<Func<TEntity, TProperty>>[] propertySelectors)
    {
        var result = _dbSet.AsQueryable();

        for (int i = 0; i < propertySelectors.Length; i++)
            result = result.Include(propertySelectors[i]);

        return result;
    }

    public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
    {
        var result = _dbSet.Where(predicate).ToList();
        return result;
    }

    public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await _dbSet.Where(predicate).ToListAsync();
        return result;
    }
    #endregion

    #region Insert/Add Section
    public TEntity Add(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public int AddAndGetId(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();

        return entity.Id;
    }

    public async Task<int> AddAndGetIdAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public List<TEntity> AddRange(List<TEntity> entity)
    {
        _dbSet.AddRange(entity);
        _context.SaveChanges();

        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        _dbSet.AddRange(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region First/Single Section
    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _dbSet.FirstOrDefault(predicate);
        return entity;
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(predicate);
        return entity;
    }

    public TEntity Single(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Single(predicate);
    }

    public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.SingleAsync(predicate);
    }
    #endregion

    #region Update Section
    public TEntity Update(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Modified;
        _context.SaveChanges();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region Delete Section
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public void Delete(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _dbSet.FirstOrDefault(predicate);
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _dbSet.FirstOrDefault(predicate);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    #endregion
}