using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IGeneralRepository<T> where T : class, IEntity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
    }
}
