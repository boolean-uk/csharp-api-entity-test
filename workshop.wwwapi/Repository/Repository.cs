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

        // Patients ------------------------------------------
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.Include(p => p.Appointments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            return patient;
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        // Doctors --------------------------------------------
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var patient = await _databaseContext.Doctors.Include(d => d.Appointments)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            return patient;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        // Appointments ----------------------------------------
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int patientId, int doctorId)
        {
            var patient = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);

            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            return patient; 
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==doctorId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
