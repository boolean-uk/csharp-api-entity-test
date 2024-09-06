using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
    }
}
