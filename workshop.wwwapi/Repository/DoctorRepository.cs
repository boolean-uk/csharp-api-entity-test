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
            _databaseContext = db;
        }

        public Task<Doctor> CreateDoctor(Doctor newDoctor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public Task<Doctor> GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
