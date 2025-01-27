using System.Linq.Expressions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T, U> 
        where T : class 
        where U : struct
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeChains);

        Task<T> Get(U id);
        Task<T> GetWithIncludes(U id, params Func<IQueryable<T>, IQueryable<T>>[] includeChains);


        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(U id);
        Task Save();
        Task<T> Find(Expression<Func<T, bool>> condition);
        Task<T> FindWithIncludes(Expression<Func<T, bool>> condition, params Func<IQueryable<T>, IQueryable<T>>[] includeChains);
    }
}
