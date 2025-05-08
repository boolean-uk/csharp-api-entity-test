using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private DatabaseContext _databaseContext;
        public DoctorRepository(DatabaseContext db)
        {
            _databaseContext = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }
    }
}
