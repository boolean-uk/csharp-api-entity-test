using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext _context;
        public GeneralRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> GetById(int id)
        {
            T entity = await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentException($"No {nameof(T)} with id: {id}");
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
