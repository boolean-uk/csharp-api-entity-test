using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(DatabaseContext db) : base(db) { }
        
        public async Task<IEnumerable<Appointment>> GetDoctorAppointments(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorIdFK == id).ToListAsync();
        }
    }
}
