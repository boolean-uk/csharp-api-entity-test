using Microsoft.EntityFrameworkCore;
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
        /*
         * PATIENT FROM HERE
         */
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p=> p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
                return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstAsync(i => i.Id == id);
        }

        public async Task<Patient> CreatePatient(string name)
        {
            Patient patient = new Patient()
            {
                FullName = name,
                Id = (_databaseContext.Patients.Count() == 0 ? 0 : _databaseContext.Patients.Max(patient => patient.Id) + 1)
            };
            _databaseContext.Add(patient);
            _databaseContext.SaveChangesAsync();
            return patient;
        }
        /*
         * DOCTOR FROM HERE
         */
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
    }
}
