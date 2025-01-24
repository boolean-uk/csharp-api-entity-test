using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private DatabaseContext _databaseContext;
        public PrescriptionRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<Prescription> CreatePrescription(Prescription newPrescription)
        {
            await _databaseContext.Prescriptions.AddAsync(newPrescription);
            await _databaseContext.SaveChangesAsync();
            return newPrescription;
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.MedicinePrescriptions)
                    .ThenInclude(mp => mp.Medicine)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.MedicinePrescriptions)
                    .ThenInclude(mp => mp.Medicine)
                .ToListAsync();
        }
    }
}
