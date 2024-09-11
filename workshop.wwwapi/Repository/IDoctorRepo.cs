using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IDoctorRepo
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> CreateDoctor(Doctor newDoctor);
    }
}
