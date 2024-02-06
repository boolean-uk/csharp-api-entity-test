using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepository : IRepository<Doctor>
    {

        DatabaseContext db;
        public DoctorRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public Task<Doctor> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor?> Get(object id)
        {
            return await db.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.ID == (int)id);
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await db.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<Doctor> Insert(Doctor entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public Task<Doctor> Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
