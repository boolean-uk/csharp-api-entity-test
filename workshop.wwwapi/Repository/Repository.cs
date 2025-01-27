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
            return await _databaseContext.Patients.Include(x => x.Appointments).ThenInclude(y => y.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(b => b.Appointments).ThenInclude(y => y.Doctor).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Patient> AddPatient(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(x => x.Appointments).ThenInclude(y => y.Patient).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(b => b.Appointments).ThenInclude(y => y.Patient).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).Include(x => x.Doctor).Include(y => y.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).Include(x => x.Doctor).Include(y => y.Patient).ToListAsync();
        }
        public async Task<Appointment> GetAppointmentsById(int id)
        {
            return await _databaseContext.Appointments.Include(x => x.Doctor).Include(y => y.Patient).FirstAsync(a => a.id == id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(x => x.Doctor).Include(y => y.Patient).ToListAsync();
        }
        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

    }
}
