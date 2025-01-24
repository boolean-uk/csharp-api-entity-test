using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return null;
            }
            return patient;
        }

        public async Task<Patient> CreatePatient(Patient entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.Include(a => a.Appointments).ThenInclude(b => b.Patient).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            var entity = await _db.Doctors
                .Include(a => a.Appointments)
                .ThenInclude(b => b.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);

            return entity;
        }

        public async Task<Doctor> CreateDoctor(Doctor entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments.Include(a => a.Doctor).Include(b => b.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Include(a => a.Patient).Where(a => a.DoctorId==id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Include(a => a.Doctor).Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(Appointment entity)
        {
            await _db.Appointments.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
