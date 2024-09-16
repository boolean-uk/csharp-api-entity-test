using System.Linq.Expressions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<TEntity>> GetEntities<TEntity>() where TEntity : class;
        Task<IEnumerable<TEntity>> GetEntities<TEntity>(params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class;
        Task<TEntity> GetEntity<TEntity>(int id) where TEntity : class;
        Task<TEntity> CreateEntity<TEntity>(TEntity entity) where TEntity : class;
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
    }
}
