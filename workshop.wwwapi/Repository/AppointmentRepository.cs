using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        DatabaseContext _db;
        public AppointmentRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Appointments)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Appointments)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDoctor(int id)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Appointments)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Appointments)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatient(int id)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Appointments)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Appointments)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorAndPatient(int doctorId, int patientId)
        {
            return await _db.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Appointments)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Appointments)
                .Where(a => a.DoctorId == doctorId && a.PatientId == patientId)
                .ToListAsync();
        }
    }
}
