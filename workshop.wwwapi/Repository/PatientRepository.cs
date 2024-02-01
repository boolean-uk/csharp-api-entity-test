using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;

namespace workshop.wwwapi.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private DatabaseContext _databaseContext;
        public PatientRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<Patient?> Get(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient?> Create(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
    }
}
