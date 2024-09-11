using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepo
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
    }
}
