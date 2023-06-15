using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL;

public interface IRepository<T> where T : class
{
    Task<IQueryable<T>> GetAllAsync(string[]? includes = null);
    Task<IEnumerable<T>> GetAllAsNoTrackingAsync(
          int skip, int take
        , string[]? includes = null
        , Expression<Func<T, bool>>? criteria=null);
    IEnumerable<TResult> GetGrouped<TKey, TResult>(
        Expression<Func<T, TKey>> groupingKey,
        Expression<Func<IGrouping<TKey, T>, TResult>> resultSelector,
        Expression<Func<T, bool>>? criteria = null);


        Task<T> GetByIdAsync(int id); 
    Task<T> GetByCriteriaAsync(Expression<Func<T,bool>> criteria, string[]? includes = null);
    Task<bool> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);  
    void DeleteById(T entity);
    void DeleteRange(List<T> entities);
    public void AddRange(List<T> entities);
    public void SaveChanges();
}