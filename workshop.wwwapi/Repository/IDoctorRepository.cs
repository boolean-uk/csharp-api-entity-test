using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();

    }
}
