using System.Linq.Expressions;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWithCustomIncludes(Func<IQueryable<T>, IQueryable<T>> includeQuery);
        Task<T> GetSingleWithCustomIncludes(int id, Func<IQueryable<T>, IQueryable<T>> includeQuery);
    }
}
