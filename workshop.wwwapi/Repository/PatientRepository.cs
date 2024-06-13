using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int patientId)
        {
            Patient? patient = await _databaseContext.Patients
                .Where(p => p.Id == patientId)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync();

            if (patient == null)
            {
                return null;
            }
            return patient;
        }        

        public async Task<Patient> CreatePatient(string FullName, string Email)
        {
            if (FullName == "" || Email == "") return null; 
           

            Patient? patient = new Patient(FullName, Email);
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
     
  

       
    }
}
