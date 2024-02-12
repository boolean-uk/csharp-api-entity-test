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

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstAsync(i => i.Id == id);
        }

        public async Task<Doctor> CreateDoctor(string name)
        {
            Doctor doctor = new Doctor() 
            {
                FullName = name, 
                Id = (_databaseContext.Doctors.Count() == 0 ? 0 :  (_databaseContext.Doctors.Max(doctor => doctor.Id) + 1))
            };
            _databaseContext.Add(doctor);
            _databaseContext.SaveChangesAsync();
            return doctor;
        }
        /*
         * APPOINTMENT METHODS FROM HERE
         */

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentById(int docID, int patID)
        {
            return await _databaseContext.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(d => d.DoctorId == docID && d.PatientId == patID)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(int docID, int patID)
        {
            Appointment appointment = new Appointment()
            {
                Booking = DateTime.UtcNow,
                DoctorId = docID,
                PatientId = patID
            };
            _databaseContext.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }
    }
}
