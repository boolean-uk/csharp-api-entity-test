using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.PrescriptionModels;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Repository.ExtensionRepository
{
    public class PrescriptionRepo : Repository<Prescription>
    {
        private readonly DatabaseContext _db;

        public PrescriptionRepo(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Prescription>> Get()
        {
            return await _db.Prescriptions
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p=>p.Appointment)
                    .ThenInclude(a =>a.Patient)
                .Include(p => p.PrescriptionMedicines)
                    .ThenInclude(pm => pm.Medicine)
                .ToListAsync();
        }
    }
}