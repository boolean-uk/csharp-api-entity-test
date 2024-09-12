using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PatientRepository : IPatientRepository
    {

        private DatabaseContext _databaseContext;
        public PatientRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> CreatePatient(Patient newPatient)
        {
            await _databaseContext.Patients.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();

            return newPatient;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
