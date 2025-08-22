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
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Where(a => a.DoctorId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Where(a => a.PatientId == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<Patient> AddAsync(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }
        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
