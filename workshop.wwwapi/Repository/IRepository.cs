using System.Linq.Expressions;

namespace workshop.wwwapi.Repository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllWithIncludes(
        Func<IQueryable<T>, IQueryable<T>> include);
    Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<T?> GetWithIncludes(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IQueryable<T>> include);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}