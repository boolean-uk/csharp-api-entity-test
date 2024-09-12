using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Repository
{

    public class PrescriptionRepo : IPrescriptionRepo
    {
        private DatabaseContext _databaseContext;
        public PrescriptionRepo(DatabaseContext db)
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
