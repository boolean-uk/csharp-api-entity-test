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
            return await _databaseContext.Patients.Include(a => a.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ToListAsync();
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            _databaseContext.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetAPatient(int id)
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> GetADoctor(int id)
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId==id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int patientId, int doctorId)
        {
            return await _databaseContext.Appointments.FindAsync(patientId, doctorId);
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
