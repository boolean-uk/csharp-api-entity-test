using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        private DatabaseContext _db;
        public DoctorRepository(DatabaseContext db)
        {
            _db = db;
        }

        //public async Task<IEnumerable<Doctor>> GetDoctors()
        //{
        //    return await _databaseContext.Doctors.ToListAsync();
        //}
    }
}
