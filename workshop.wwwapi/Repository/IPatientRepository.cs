using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int patientId);
        Task<Patient> CreatePatient(string FullName, string Email, string Gender);
    }
}
