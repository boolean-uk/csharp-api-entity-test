using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        // --- Patients ---
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> CreatePatient(string PatientName)
        {
            if (PatientName == "")
                return null;

            Patient patient = new Patient() { FullName = PatientName };
            await _databaseContext.Patients.AddAsync(patient);

            _databaseContext.SaveChanges();
            return patient;
        }

        // --- Doctors ---
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctor(int id)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> CreateDoctor(string doctorName)
        {
            if (doctorName == "")
                return null;

            Doctor doctor = new Doctor() { FullName = doctorName };
            await _databaseContext.Doctors.AddAsync(doctor);

            _databaseContext.SaveChanges();
            return doctor;
        }
        // --- Appointments ---
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await _databaseContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(x => x.PatientIdFK == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorIdFK == id).ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);

            _databaseContext.SaveChanges();
            return appointment;
        }
    }
}
