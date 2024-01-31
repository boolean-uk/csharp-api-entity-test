using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using static workshop.wwwapi.Repository.IRepository;

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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatient(int patientId)
        {
             return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == patientId);
               
        }

        public async Task<Patient?> CreatePatient(Patient newPatient)
        {
            if (newPatient == null) { return null; }
            _databaseContext.Patients.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();
            return newPatient; 
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int doctorId)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.Id == doctorId);
            
        }

        public async Task<Doctor?> CreateDoctor(Doctor newDoctor)
        {
            if (newDoctor == null) { return null; }
            _databaseContext.Doctors.AddAsync(newDoctor);
            await _databaseContext.SaveChangesAsync();
            return newDoctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
           
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(DateTime Booking, Patient patient, Doctor doctor)
        {
            
            if(patient == null || doctor == null) return null;
            var appointment = new Appointment
            {
                Booking = Booking,
                PatientId = patient.Id,
                Patient = patient,
                DoctorId = doctor.Id,
                Doctor = doctor
            };

            try
            {
                await _databaseContext.Appointments.AddAsync(appointment);
            }
            catch (Exception ex)
            {
                // failed to create appointment, maybe the ids are wrong for student or course
                return null;
            }
            _databaseContext.SaveChangesAsync();
            return appointment;
        }

    }
}
