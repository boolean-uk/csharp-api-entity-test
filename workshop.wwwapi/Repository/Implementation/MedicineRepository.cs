using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.Implementation
{
    public class MedicineRepository : IMedicineRepository
    {
        private DatabaseContext _db;
        public MedicineRepository(DatabaseContext db) 
        { 
            _db = db;
        }

        public async Task<IEnumerable<Medicine>> Get()
        {
            return await _db.Medicines
                .Include(m => m.Prescriptions)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Patient)

                .Include(m => m.Prescriptions)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Doctor)

                .Include(m => m.Prescriptions)
                .ToListAsync();
        }

        public async Task<Medicine?> Get(int id)
        {
            return await _db.Medicines
                .Include(m => m.Prescriptions)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Patient)

                .Include(m => m.Prescriptions)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Doctor)

                .Include(m => m.Prescriptions)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Medicine> Create(Medicine medicine)
        {
            _db.Medicines.Add(medicine);
            await _db.SaveChangesAsync();
            return medicine;
        }

        public async Task<Medicine> Update(Medicine medicine)
        {
            _db.Medicines.Update(medicine);
            await _db.SaveChangesAsync();
            return medicine;
        }
    }
}
