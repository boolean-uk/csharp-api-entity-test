using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor newDoctor);
    }
}
