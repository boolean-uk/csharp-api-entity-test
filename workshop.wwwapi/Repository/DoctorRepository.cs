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

        public async Task<Doctor> CreateDoctor(Doctor newDoctor)
        {
            await _databaseContext.Doctors.AddAsync(newDoctor);
            await _databaseContext.SaveChangesAsync();
            return newDoctor;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FindAsync(id);
        }
    }
}
