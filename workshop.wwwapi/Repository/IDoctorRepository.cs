using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> Get();
        Task<Doctor?> Get(int id);
        Task<Doctor?> Create(Doctor doctor);
    }
}
