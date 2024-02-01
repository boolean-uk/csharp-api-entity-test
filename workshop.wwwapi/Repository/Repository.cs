using System.IO.Compression;
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
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            Patient? patient = await _databaseContext.Patients
                .Where(p => p.Id == id)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync();
            if (patient == null)
            {
                return null;
            }
            return patient;
        }
        public async Task<Doctor?> GetDoctorById(int id)
        {
            Doctor? doctor = await _databaseContext.Doctors
                .Where(p => p.Id == id)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync();
            if (doctor == null)
            {
                return null;
            }
            return doctor;
        }
        public async Task<IEnumerable<Appointment>?> GetAppointmentsByDoctor(int id)
        {
            List<Appointment>? appointment = await _databaseContext.Appointments
                .Where(a => a.DoctorId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }
        public async Task<IEnumerable<Appointment>?> GetAppointmentsByPatient(int id)
        {
            List<Appointment>? appointment = await _databaseContext.Appointments
                .Where(a => a.PatientId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<Appointment?> GetAppointmentsByCompositeId(int doctorid, int patientid, DateTime booking)
        {
            Appointment? appointment = await _databaseContext.Appointments
                .Where(a => a.PatientId == patientid)
                .Where(a => a.DoctorId == doctorid)
                .Where(a => a.Booking == booking)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync();
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<Patient> CreatePatient(string name)
        {
            Patient patient = new Patient(name);
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Doctor> CreateDoctor(string name)
        {
            Doctor doctor = new Doctor(name);
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Appointment> CreateAppointment(int doctorid, int patientid, DateTime booking)
        {
            Appointment appointment = new Appointment(doctorid, patientid, booking);
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            
            return await GetAppointmentsByCompositeId(doctorid, patientid, booking);
        }
    }
}
