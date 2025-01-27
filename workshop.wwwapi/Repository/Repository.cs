using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository<T, U> : IRepository<T, U>
        where T : class
        where U : struct
    {
        private DataContext _db;
        private DbSet<T> _table = null!;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(U id)
        {
            T entity = await Get(id);
            _table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(U id)
        {
            T? entity = await _table.FindAsync(id);
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            return await query.ToListAsync();
        }

        public async Task<T> GetWithIncludes(U id, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            T? entity = await query.FirstOrDefaultAsync(e => EF.Property<U>(e, "Id").Equals(id));
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> condition)
        {
            T? entity = await _table.FirstOrDefaultAsync(condition);
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }
        public async Task<T> FindWithIncludes(Expression<Func<T, bool>> condition, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            T? entity = await query.FirstOrDefaultAsync(condition);
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        private IQueryable<T> GetIncludeTable(params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = _table;
            foreach (var includeChain in includeChains)
            {
                query = includeChain(query);
            }
            return query;
        }
    }
}
