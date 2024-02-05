using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private DatabaseContext _db;
        public DoctorRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            return await _db.Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Doctor?> Get(int id)
        {
            return await _db.Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor?> Create(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }
    }
}
