using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T> where T : class /////////////
    {
        DbSet<T> Table { get; } // NOTE: Added for BaseDTO class... Should probably be a private getter only exposed to BaseDTO instances...
        Task<IEnumerable<T>> GetEntries(params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<T?> GetEntry(Func<IQueryable<T>, IQueryable<T>> id, params Func<IQueryable<T>, IQueryable<T>>[] expressions);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);

        Task<T?> CreateEntry(T entry);
    }
}
