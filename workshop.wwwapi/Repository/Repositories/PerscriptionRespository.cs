using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        DatabaseContext db;
        public PrescriptionRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public Task<Prescription> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<Prescription?> Get(object id)
        {
            return await db.Prescriptions.Include(p => p.Appointment).ThenInclude(a => a.Doctor)
                         .Include(p => p.Appointment).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.ID == (int)id);
        }

        public async Task<IEnumerable<Prescription>> GetAll()
        {
            return await db.Prescriptions.Include(p => p.Appointment).ThenInclude(a => a.Doctor)
                         .Include(p => p.Appointment).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<Prescription?> GetByAppointmentID(int id)
        {
            return await db.Prescriptions.Include(p => p.Appointment).ThenInclude(a => a.Doctor)
                         .Include(p => p.Appointment).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.AppointmentID == id);
        }

        public async Task<Prescription> Insert(Prescription entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            var result = await Get(entity.ID);
            return result;
        }

        public Task<Prescription> Update(Prescription entity)
        {
            throw new NotImplementedException();
        }
    }
}
