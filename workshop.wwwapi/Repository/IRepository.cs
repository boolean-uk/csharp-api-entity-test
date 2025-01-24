using System.Linq.Expressions;

namespace workshop.wwwapi.Repository
{
    // CRUD = Create, Read, Update, Delete
    public interface IRepository<T>
    {
        // Create
        Task<T> Insert(T entity);

        // Read
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);

        // Update
        Task<T> Update(T entity);

        // Delete
        Task<T> Delete(object id);

        // Save
        Task Save();
    }
}
