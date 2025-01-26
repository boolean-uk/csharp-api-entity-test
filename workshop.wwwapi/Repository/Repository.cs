using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _databaseContext;

        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        // Patients
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        // Appointments
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}

