using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Repository.ExtensionRepository
{
    public class PatientRepo : Repository<Patient>
    {
        private readonly DatabaseContext _db;

        public PatientRepo(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Patient>> Get()
        {
            return await _db.Patients
                            .Include(p => p.Appointments)
                                .ThenInclude(a => a.Doctor)
                            .ToListAsync();
        }

        public override async Task<Patient> GetById(object id)
        {
            var patient = await _db.Patients
                            .Include(p => p.Appointments)
                                .ThenInclude(a => a.Doctor)
                            .FirstOrDefaultAsync(p => p.Id == (int)id);

            return patient == null ? throw new KeyNotFoundException($"An author with the ID {id} was not found.") : patient;
        }
    }
}
