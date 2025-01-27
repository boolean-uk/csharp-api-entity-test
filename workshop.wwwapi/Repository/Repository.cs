using System.Linq.Expressions;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private DatabaseContext _databaseContext;
        /////////
        private DbSet<T> _table = null!;
        public DbSet<T> Table { get => _table; }
        /////////
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
            _table = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetEntries(params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> q = _table.AsQueryable();
            
            foreach (var inc in includes)
                q = inc.Invoke(q);

            return await q.ToArrayAsync();
        }

        public async Task<T?> GetEntry(Func<IQueryable<T>, IQueryable<T>> id, params Func<IQueryable<T>, IQueryable<T>>[] expressions)
        {
            IQueryable<T> q = _table.AsQueryable();

            q = id.Invoke(q);
            foreach (var ex in expressions)
            {
                q = ex.Invoke(q);
            }

            return await q.FirstOrDefaultAsync();
        }
        public async Task<T?> CreateEntry(T entry)
        {
            var a = await _table.AddAsync(entry);
            await _databaseContext.SaveChangesAsync();
            return entry;

        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

       
    }
}
