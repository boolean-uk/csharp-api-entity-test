using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.DTOs.Prescriptions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PrescriptionRepository
    {
        private readonly DatabaseContext _context;
        public PrescriptionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAll()
        {
            IEnumerable<Prescription> prescriptions = await _context.Prescriptions
                .Include(p => p.Medicines)
                .ToListAsync();
            return prescriptions;
        }

        public async Task<Prescription> GetById(int id)
        {
            Prescription prescription = await _context.Prescriptions
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ArgumentException($"No prescription with id: {id}");
            return prescription;
        }

        public async Task<Prescription> Add(AddMedicinePrescriptionDTO addDTO)
        {
            Prescription prescription = new();
            List<Medicine> medicines = await _context.Medicines
                .Where(m => addDTO.MedicineId.Contains(m.Id))
                .ToListAsync();
            if (medicines.Count == 0)
            {
                throw new ArgumentException("No medicines with given IDs!");
            }
            prescription.Medicines = medicines;
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }
    }
}
