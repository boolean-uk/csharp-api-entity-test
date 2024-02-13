using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TEntity>> GetEntities<TEntity>() where TEntity : class
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetEntities<TEntity>(params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class
        {
            if (includeExpressions.Any())
            {
                DbSet<TEntity> entities = _db.Set<TEntity>();
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(entities, (current, expression) => current.Include(expression));
            }
            return await _db.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetEntity<TEntity>(int id) where TEntity : class
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
        }
        public async Task<TEntity> CreateEntity<TEntity>(TEntity entity) where TEntity: class
        {
            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        
    }
}
