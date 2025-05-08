using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository.SpecificRepositories
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        private readonly DatabaseContext _context;

        public PrescriptionRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient) 
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor) 
                .ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionWithDetails(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByAppointmentId(int patientId, int doctorId)
        {
            return await _context.Prescriptions
                .Where(p => p.PatientId == patientId && p.DoctorId == doctorId)
                .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
                .ToListAsync();
        }
    }
}
