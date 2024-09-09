using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using workshop.wwwapi.Data;

/*
namespace workshop.wwwapi.Repository
{
    public class GenericRepository<Model, View, DTO> : IGenericRepository<Model, View, DTO>
        where Model : class
        where View : class
        where DTO : class
    {
        private DatabaseContext _db;
        private DbSet<Model> _dbSet;

        public GenericRepository(DatabaseContext db)
        {
            _db = db;
            _dbSet = _db.Set<Model>();
        }

        public async Task<DTO> GetAll(string inclusion)
        {
            var table = await _dbSet.Include(inclusion).ToListAsync();

        }
    }
}*/
