using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(DatabaseContext db) : base(db) { }

        public async Task<IEnumerable<Appointment>> GetPatientAppointments(int id)
        {
            return await _db.Appointments.Where(a => a.PatientIdFK == id).ToListAsync();
        }
    }
}
