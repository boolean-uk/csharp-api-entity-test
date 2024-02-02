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
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FirstAsync(a=>a.Id==id);
        }

        public async Task<Patient> CreatePatient(string fullname)
        {
            Patient patient = new Patient()
            {
                Id = _databaseContext.Patients.Max(p => p.Id) + 1,
                FullName = fullname
            };
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }
    }
}
