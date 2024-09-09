using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(int id);
        Task Add(T entity);

        Task updateAsync(T entity);

        Task deleteAsync(int id);
       
    }
}
