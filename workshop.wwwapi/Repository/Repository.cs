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

        public async Task<Patient?> GetPatientById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(p => p.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Patients.FindAsync(id);
                default:
                    return null;
            }
        }

        public async Task<Patient?> CreatePatient(string fullName)
        {   
            if (string.IsNullOrEmpty(fullName))
            {
                return null;
            }
            var patient = new Patient
            {
                FullName = fullName
            };
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(d => d.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Doctors.FindAsync(id);
                default:
                    return null;
            }
        }

        public async Task<Doctor?> CreateDoctor(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return null;
            }
            var doctor = new Doctor
            {
                FullName = fullName
            };
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(DateTime booking, Doctor doctor, Patient patient)
        {
            if (doctor == null || patient == null)
            {
                return null;
            }
            var appointment = new Appointment
            {
                Booking = booking,
                DoctorId = doctor.Id,
                PatientId = patient.Id
            };
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }   
    

        public async Task<Appointment?> GetAppointmentByPatientId(int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.PatientId == patientId);
        }

        public async Task<Appointment?> GetAppointmentByDoctorId(int doctorId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.DoctorId == doctorId);
        }
    }
}
