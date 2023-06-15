using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ShippingSystemContext _context;
    private readonly DbSet<T> _dbSet;
    public Repository(ShippingSystemContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IQueryable<T>> GetAllAsync(string[]? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await Task.FromResult(query);
    }


    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id); 
    }

    public async Task<T> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, string[]? includes = null)
    {
        var query = _dbSet.AsQueryable().Where(criteria).AsNoTracking();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.FirstOrDefaultAsync(); ;
    }

    public async Task<bool> AddAsync(T entity)
    {
        var result = await _dbSet.AddAsync(entity);

        return (result != null) ? true : false;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }

    public void DeleteById(T entity)
    {
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public void DeleteRange(List<T> entities)
    {
        if(entities != null)
            _dbSet.RemoveRange(entities);
    }

    public void AddRange(List<T> entities)
    {
        if (entities != null)
            _dbSet.AddRange(entities);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAllAsNoTrackingAsync(
          int pageNumber, int pageSize
        , string[]? includes = null
        , Expression<Func<T, bool>>? criteria = null)
    {
        int skip = (pageNumber - 1) * pageSize;
        int take = pageSize;

        IQueryable<T> query = _dbSet;

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        if (criteria != null)
        {
            query = query.Where(criteria);
        }

        return await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
    }

    public IEnumerable<TResult> GetGrouped<TKey, TResult>(Expression<Func<T, TKey>> groupingKey, Expression<Func<IGrouping<TKey, T>, TResult>> resultSelector, Expression<Func<T, bool>>? criteria = null)
    {
        var query = _dbSet.AsQueryable();

        if (criteria != null)
        {
            query = query.Where(criteria);
        }

        return query.GroupBy(groupingKey).Select(resultSelector);
    }
}