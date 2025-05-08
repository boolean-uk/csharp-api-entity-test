using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> Get();
        Task<Patient> Get(int id);
        Task<Patient> Create(Patient patient);
    }
}
