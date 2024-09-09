using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient newPatient);
    }
}
