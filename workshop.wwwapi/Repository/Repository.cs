using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;

        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(A => A.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(A => A.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription).ThenInclude(p => p.Medicines)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }

        public async Task<Patient?> CreateNewPatient(string fullname)
        {
            if (fullname == "") { return null; }
            Patient p = new Patient() { FullName = fullname };
            EntityEntry<Patient> res = await _databaseContext.Patients.AddAsync(p);
            _databaseContext.SaveChanges();

            return p;
        }

        public async  Task<Appointment?> GetAppointmentsById(int id)
        {
            return await _databaseContext.Appointments
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .Include(a => a.Prescription).ThenInclude(p => p.Medicines)
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();
        }
    }
}