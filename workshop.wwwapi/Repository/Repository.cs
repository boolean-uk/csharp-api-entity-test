using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext _db;
        protected DbSet<T> _table = null;
        public Repository(DatabaseContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<T> Delete(int id)
        {
            T entity = await _table.FindAsync(id);
            _table.Remove(entity);

            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByID(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            await _table.AddAsync(entity);

            _db.SaveChanges();
            return entity;
        }
    }
}