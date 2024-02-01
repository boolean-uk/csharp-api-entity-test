using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            return await _databaseContext.Patients.Select(x => new PatientDTO() { PatientId = x.Id, PatientName = x.FullName }).ToListAsync();
        }

        public async Task<PatientDTO?> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Where(x => x.Id == id).Select(x => new PatientDTO() { PatientId = x.Id, PatientName = x.FullName }).FirstOrDefaultAsync();
        }
    }
}
