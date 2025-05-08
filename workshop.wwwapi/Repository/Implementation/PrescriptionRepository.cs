using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.Implementation
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private DatabaseContext _db;
        public PrescriptionRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Prescription> Create(Prescription prescription)
        {
            Appointment? appointment = await _db.Appointments.FirstOrDefaultAsync(a => a.Id == prescription.AppointmentId);
            if (appointment == null)
                throw new Exception("Invalid appointment id");

            if (appointment.Prescription != null)
                throw new Exception("This appointment already has a prescription");

            _db.Prescriptions.Add(prescription);
            await _db.SaveChangesAsync();
            return prescription;
        }

        public async Task<IEnumerable<Prescription>> Get()
        {
            return await _db.Prescriptions
                .Include(p => p.Medicines)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Prescription?> Get(int id)
        {
            return await _db.Prescriptions
                .Include(p => p.Medicines)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Prescription> Update(Prescription prescription)
        {
            _db.Prescriptions.Update(prescription);
            await _db.SaveChangesAsync();
            return prescription;
        }
    }
}
