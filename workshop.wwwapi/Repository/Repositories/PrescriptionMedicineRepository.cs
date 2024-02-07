using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain.Junctions;

namespace workshop.wwwapi.Repository.Repositories
{
    public class PrescriptionMedicineRepository : IPrescriptionMedicineRepository
    {
        DatabaseContext db;
        public PrescriptionMedicineRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public Task<PrescriptionMedicine> Delete(object id1, object id2)
        {
            throw new NotImplementedException();
        }

        public async Task<PrescriptionMedicine?> Get(object prescriptionID, object medicineID)
        {
            return await db.PrescriptionMedicines.Include(pm => pm.Medicine)
                        .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Doctor)
                        .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
                        .FirstOrDefaultAsync(pm => pm.PrescriptionID == (int)prescriptionID && pm.MedicineID == (int)medicineID);
        }

        public async Task<IEnumerable<PrescriptionMedicine>> GetAll()
        {
            return await db.PrescriptionMedicines.Include(pm => pm.Medicine)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Doctor)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
            .ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionMedicine>> GetAllByPrescriptionID(object id)
        {
            return await db.PrescriptionMedicines.Include(pm => pm.Medicine)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Doctor)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
            .Where(pm => pm.PrescriptionID == (int)id)
            .ToListAsync();
        }

        public async Task<PrescriptionMedicine> Insert(PrescriptionMedicine entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            var result = await Get(entity.PrescriptionID, entity.MedicineID);
            return result;
        }

        public Task<PrescriptionMedicine> Update(PrescriptionMedicine entity)
        {
            throw new NotImplementedException();
        }
    }
}
