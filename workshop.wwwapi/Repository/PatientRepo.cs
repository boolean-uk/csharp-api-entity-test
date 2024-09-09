using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private DatabaseContext _dbContext;

        public PatientRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _dbContext.Patients.ToListAsync();
        }
    }
}
