using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Repository.ExtensionRepository
{
    public class DoctorRepo: Repository<Doctor>
    {
        private readonly DatabaseContext _db;

        public DoctorRepo(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Doctor>> Get()
        {
            return await _db.Doctors
                            .Include(d => d.Appointments)
                                .ThenInclude(a => a.Patient)
                            .ToListAsync();
        }

        public override async Task<Doctor> GetById(object id)
        {
            var doctor = await _db.Doctors
                            .Include(d => d.Appointments)
                                .ThenInclude(a => a.Patient)
                            .FirstOrDefaultAsync(d => d.Id == (int)id);

            return doctor == null ? throw new KeyNotFoundException($"An author with the ID {id} was not found.") : doctor;
        }
    }
}
