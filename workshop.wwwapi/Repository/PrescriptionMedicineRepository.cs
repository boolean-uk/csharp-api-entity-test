using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain.JunctionModels.PrescriptionMedicine;

namespace workshop.wwwapi.Repository
{
    public class PrescriptionMedicineRepository : IRepository<PrescriptionMedicine>
    {
        DatabaseContext db;
        public PrescriptionMedicineRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public Task<PrescriptionMedicine> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<PrescriptionMedicine?> Get(object id)
        {
            return await db.PrescriptionMedicines.Include(pm => pm.Medicine)
                        .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Doctor)
                        .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
                        .FirstOrDefaultAsync(pm => new PrescriptionMedicineID(pm.PrescriptionID, pm.MedicineID) == (PrescriptionMedicineID)id);
        }

        public async Task<IEnumerable<PrescriptionMedicine>> GetAll()
        {
            return await db.PrescriptionMedicines.Include(pm => pm.Medicine)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Doctor)
            .Include(pm => pm.Prescription).ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
            .ToListAsync();
        }

        public async Task<PrescriptionMedicine> Insert(PrescriptionMedicine entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            var result = await Get(new PrescriptionMedicineID(entity.PrescriptionID, entity.MedicineID));
            return result;
        }

        public Task<PrescriptionMedicine> Update(PrescriptionMedicine entity)
        {
            throw new NotImplementedException();
        }
    }
}
