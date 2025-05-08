using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly DatabaseContext _context;

        public PatientRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientWithAppointments(int id)
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
