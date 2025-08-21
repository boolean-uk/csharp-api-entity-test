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
        // Patients
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient> CreatePatient(Patient model)
        {
            await _db.Patients.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        // Doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _db.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task<Doctor> CreateDoctor(Doctor model)
        {
            await _db.Doctors.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        // Appointments
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments
                .Where(a => a.DoctorId == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments
                .Where(a => a.PatientId == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(Appointment model)
        {
            await _db.Appointments.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
