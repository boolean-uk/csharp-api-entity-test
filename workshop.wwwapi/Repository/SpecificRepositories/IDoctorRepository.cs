using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> GetDoctorWithAppointments(int id);
    }
}
