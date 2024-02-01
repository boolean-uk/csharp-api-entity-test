using Microsoft.EntityFrameworkCore;
using System.Numerics;
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
            return await _databaseContext.Patients.Include(x => x.Appointments).ThenInclude(x => x.Doctor).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(x => x.Appointments).ThenInclude(x => x.Patient).ToListAsync();
        }


        public async Task<Patient?> GetPatientByID(int id)
        {
            return await _databaseContext.Patients.Include(x => x.Appointments).ThenInclude(x => x.Doctor).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> CreatePatient(string fullName)
        {
            Patient patient = new Patient();
            patient.FullName = fullName;
            patient.Appointments = new List<Appointment>();
            await _databaseContext.Patients.AddAsync(patient);
            _databaseContext.SaveChanges();
            return patient;
        }

        public async Task<Doctor?> GetDoctorByID(int id)
        {
            return await _databaseContext.Doctors.Include(x => x.Appointments).ThenInclude(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> CreateDoctor(string fullName)
        {
            Doctor doctor = new Doctor();
            doctor.FullName = fullName;
            doctor.Appointments = new List<Appointment>();
            await _databaseContext.Doctors.AddAsync(doctor);
            _databaseContext.SaveChanges();

            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(x => x.Patient).Include(x => x.Doctor).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(DateTime booking, Patient patient, Doctor doctor)
        {
            Appointment appointment = new Appointment();
            appointment.Booking = booking;
            appointment.Patient = patient;
            appointment.Doctor = doctor;
            patient.Appointments.Add(appointment);
            doctor.Appointments.Add(appointment);
            await _databaseContext.Appointments.AddAsync(appointment);
            _databaseContext.SaveChanges();
            return appointment;
        }
    }
}
