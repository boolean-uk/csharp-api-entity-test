using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO?> GetPatientById(int id);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO?> GetDoctorById(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientId(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorId(int id);

    }
}
