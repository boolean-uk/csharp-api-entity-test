using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        DatabaseContext _db;
        public AppointmentRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task<Appointment?> Get(int id)
        {
            return _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                    .ThenInclude(p => p.Medicines)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                    .ThenInclude(p => p.Medicines)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDoctor(int id)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                    .ThenInclude(p => p.Medicines)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatient(int id)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                    .ThenInclude(p => p.Medicines)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorAndPatient(int doctorId, int patientId)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                    .ThenInclude(p => p.Medicines)
                .Where(a => a.DoctorId == doctorId && a.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<Appointment?> Create(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }
    }
}
