using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetPatientWithAppointments(int id);
    }
}
