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

        public Repository(DatabaseContext dataContext)
        {
            _db = dataContext;
            _table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return _table.ToList();
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(object id)
        {
            T entity = _table.Find(id);
            _table.Remove(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            return _table.Find(id);
        }
        public async Task<T> GetByCompositKey(int id1, int id2)
        {
            
            return await _table.FindAsync(id1, id2);
        }
        public async Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public IQueryable<T> GetQueryable()
        {
            return _table;
        }
        public async Task<IEnumerable<T>> GetWithNestedIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeActions)
        {
            IQueryable<T> query = _table;

            foreach (var includeAction in includeActions)
            {
                query = includeAction(query);
            }

            return await query.ToListAsync();
        }
        public async Task Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
