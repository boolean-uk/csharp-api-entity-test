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

        public async Task<Patient?> GetPatient(int patientId)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
        }

        public async Task<Patient?> CreatePatient(Patient newPatient)
        {
            _databaseContext.Patients.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();
            return newPatient; 
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int doctorId)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
        }

        public async Task<Doctor?> CreateDoctor(Doctor newDoctor)
        {
            _databaseContext.Doctors.AddAsync(newDoctor);
            await _databaseContext.SaveChangesAsync();
            return newDoctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(Appointment newAppointment)
        {
            _databaseContext.Appointments.AddAsync(newAppointment);
            await _databaseContext.SaveChangesAsync();
            return newAppointment; 
        }

    }
}
