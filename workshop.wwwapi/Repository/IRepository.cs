using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientAppointmentDto>> GetPatients();
        Task<PatientAppointmentDto?> GetPatient(int id);

        Task<IEnumerable<DoctorAppointmentDto>> GetDoctors();
        Task<DoctorAppointmentDto?> GetDoctor(int id);

        Task<IEnumerable<AppointmentDto>> GetAppointments();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id);
        Task<AppointmentDto?> CreateAppointment(NewAppointmentDto dto);
        
    }
}