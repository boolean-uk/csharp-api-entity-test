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
            // return await _databaseContext.Patients.ToListAsync();
            return await _databaseContext.Patients
            .Include(p => p.Appointments)
            .ThenInclude(p => p.Doctor)
            .ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            // return await _databaseContext.Doctors.ToListAsync();
            return await _databaseContext.Doctors
             .Include(p => p.Appointments)
             .ThenInclude(p => p.Patient)
             .ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Where(a => a.Id == id).ToListAsync();
        }
        public async Task<IEnumerable<Patient>> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Where(a => a.Id == id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            // return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            return await _databaseContext.Appointments
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Where(a => a.DoctorId == id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            // return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            return await _databaseContext.Appointments
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Where(a => a.PatientId == id).ToListAsync();
        }

        
    }
}
