using System.Linq.Expressions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<T> GetById(int id);
        Task<T> GetByCompositKey(int id1, int id2);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWithNestedIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeActions);
        IQueryable<T> GetQueryable();
    }
}
