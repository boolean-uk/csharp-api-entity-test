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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(p => p.Doctor).ToListAsync();

        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId == id).ToListAsync();
        }
        public async Task<Patient?> GetPatient(int patientId)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == patientId);
        }

        public async Task<Patient?> CreatePatient(string fullName)
        {
            if (fullName == "") return null;
            Patient patient = new Patient { FullName = fullName };

            try
            {
                await _databaseContext.Patients.AddAsync(patient);
            }
            catch (Exception)
            {
                return null;
            }
            _databaseContext.SaveChanges();
            return patient;
        }
        public async Task<Appointment?> AddAppointment(Patient patient, Doctor doctor, DateTime appointmentDate)
        {
            Appointment appointment = new Appointment { Patient = patient, Doctor = doctor, Booking = appointmentDate, DoctorId = doctor.Id, PatientId = patient.Id };
            try
            {
                await _databaseContext.Appointments.AddAsync(appointment);
                patient.Appointments.Add(appointment);
                doctor.Appointments.Add(appointment);
            }
            catch (Exception)
            {
                return null;
            }
            _databaseContext.SaveChanges();
            return appointment;
        }
        public async Task<Doctor?> GetDoctor(int doctorId)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.Id == doctorId);
        }
        public async Task<Doctor?> CreateDoctor(string fullName)
        {
            if (fullName == "") return null;
            Doctor doctor = new Doctor { FullName = fullName };

            try
            {
                await _databaseContext.Doctors.AddAsync(doctor);
            }
            catch (Exception)
            {
                return null;
            }
            _databaseContext.SaveChanges();
            return doctor;
        }
    }
}