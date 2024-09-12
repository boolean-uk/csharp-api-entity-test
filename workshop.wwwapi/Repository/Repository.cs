using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
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
            return await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _databaseContext.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments.FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorid)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==doctorid).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientid)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId==patientid).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(p => p.PrescribedMedicineList).ToListAsync();
        }
    }
}
