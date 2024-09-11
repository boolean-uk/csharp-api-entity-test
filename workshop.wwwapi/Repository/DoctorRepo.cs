using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private DatabaseContext _dbContext;

        public DoctorRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Doctor> CreateDoctor(Doctor newDoctor)
        {
            await _dbContext.AddAsync(newDoctor);
            await _dbContext.SaveChangesAsync();
            return newDoctor;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor = await _dbContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.Id == id);
            return doctor;
            
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
    }
}
