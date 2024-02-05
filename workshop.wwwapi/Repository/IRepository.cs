using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(object id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
    }
}
