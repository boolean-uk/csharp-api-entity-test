using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;

namespace workshop.wwwapi.Repository;

public class Repository<T>(DatabaseContext db) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);
        
        return await query.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>>[] includes, Expression<Func<object, object>> thenInclude)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);
        
        return await query.Where(predicate).ToListAsync();
    }
    
    public async Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);
        
        return await query.FirstOrDefaultAsync(predicate);
    }
    
    public async Task<T?> GetWithIncludes(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> include)
    {
        IQueryable<T> query = db.Set<T>();
 
        if (include != null)
        {
            query = include(query); // Apply the include function
        }
 
        return await query.FirstOrDefaultAsync(predicate);
    }
    
    public async Task<IEnumerable<T>> GetAllWithIncludes(Func<IQueryable<T>, IQueryable<T>> include)
    {
        IQueryable<T> query = db.Set<T>();
 
        if (include != null)
        {
            query = include(query);
        }
 
        return await query.ToListAsync();
    }

    public async Task<T> Create(T entity)
    {
        await db.Set<T>().AddAsync(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(T entity)
    {
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}