using System.Linq.Expressions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task Save();
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
    }
}
