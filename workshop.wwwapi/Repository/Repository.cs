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
                .Include(a => a.Appointments)
                .ThenInclude(b => b.Doctor)
                .ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            var entity = await _databaseContext.Patients
                .Include(a => a.Appointments)
                .ThenInclude(b => b.Doctor)
                .FirstOrDefaultAsync(patient => patient.Id == id);

            return entity;
        }

        public async Task<Patient> CreatePatient(Patient entity)
        {
            _databaseContext.Patients.Add(entity);
            await _databaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(a => a.Appointments)
                .ThenInclude(b => b.Patient)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var entity = await _databaseContext.Doctors
                .Include(a => a.Appointments)
                .ThenInclude(b => b.Patient)
                .FirstOrDefaultAsync(doctor => doctor.Id == id);

            return entity;
        }
        public async Task<Doctor> CreateDoctor(Doctor entity)
        {
            _databaseContext.Doctors.Add(entity);
            await _databaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(b => b.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment entity)
        {
            _databaseContext.Appointments.Add(entity);
            await _databaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentById(int doctorID, int patientID)
        {
            var entity = await _databaseContext.Appointments
                .Where(a => a.DoctorId == doctorID & a.PatientId == patientID)
                .Include(b => b.Doctor)
                .Include(c => c.Patient)
                .ToListAsync();

            return entity;
        }

        //public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        //{
        //    return await _databaseContext.Appointments
        //        .Where(a => a.DoctorId == id)
        //        .Include(b => b.Patient)
        //        .Include(c => c.Doctor)
        //        .ToListAsync();
        //}
    }
}
