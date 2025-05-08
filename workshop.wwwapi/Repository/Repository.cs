using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _databaseContext;
        private readonly DbSet<T> _dbSet;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
            _dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity + "element not found");
            }
            await _dbSet.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var entity = await GetOne(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(id) + "entity not found");
            }
            _dbSet.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetOne(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task updateAsync(T entity)
        {
            _dbSet.Update(entity);
            return _databaseContext.SaveChangesAsync();
        }

   

    }
}

