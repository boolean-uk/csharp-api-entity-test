using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.GenericRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _databaseContext;
        private DbSet<T> _dbSet;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
            _dbSet = _databaseContext.Set<T>();

        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity is Appointment appointment)
            {
                if (!_databaseContext.Patients.Local.Any(p => p.Id == appointment.PatientId))
                {
                    _databaseContext.Patients.Attach(new Patient { Id = appointment.PatientId });
                }

                if (!_databaseContext.Doctors.Local.Any(d => d.Id == appointment.DoctorId))
                {
                    _databaseContext.Doctors.Attach(new Doctor { Id = appointment.DoctorId });
                }
            }

            _dbSet.Add(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }
    }
}
