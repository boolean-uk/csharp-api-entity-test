using workshop.wwwapi.Models;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient_DTO>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Patient_DTO> GetPatientById(int id);

    }
}
