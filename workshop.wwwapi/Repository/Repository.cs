using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _db;
        private DbSet<T> _table = null!;

        public Repository(DatabaseContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        //public async Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = _table;
        //    foreach (var include in includes)
        //    {
        //        query = query.Include(include);
        //    }
        //    return await query.ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetWithIncludes(Func<IQueryable<T>, IQueryable<T>> includeQuery) // used for dynamic includes
        {
            IQueryable<T> query = includeQuery(_table);
            return await query.ToListAsync();
        }

    }
}
