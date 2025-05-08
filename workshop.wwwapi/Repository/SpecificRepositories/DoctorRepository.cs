using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly DatabaseContext _context;

        public DoctorRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient) 
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorWithAppointments(int id)
        {
            return await _context.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
