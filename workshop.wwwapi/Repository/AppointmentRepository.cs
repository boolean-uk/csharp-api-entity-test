using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        DatabaseContext db;
        public AppointmentRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public Task<Appointment> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> Get(object id)
        {
            return await db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.ID == (int)id);
        }

        public async Task<Appointment> GetByDoctorID(object id)
        {
            return await db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.DoctorID == (int)id);
        }

        public async Task<Appointment> GetByPatientID(object id)
        {
            return await db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.PatientID == (int)id);
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<Appointment> Insert(Appointment entity)
        {
            db.AddAsync(entity);
            db.SaveChangesAsync();
            return entity;
        }

        public Task<Appointment> Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
