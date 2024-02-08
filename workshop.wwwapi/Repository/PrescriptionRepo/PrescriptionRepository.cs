using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.PrescriptionRepo
{
    public class PrescriptionRepository : IPrescriptionRepository
    {

        private DatabaseContext _db;

        public PrescriptionRepository(DatabaseContext db) {
            _db = db;
        }

        public async Task<IEnumerable<Prescription>> getAllPrescriptions() {
            return await _db.Prescriptions.Include(p => p.PrescriptionMedicines).ThenInclude(m => m.Medicine).ToListAsync();
           
        }

       
    }
}

