using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);

        Task<IEnumerable<AppointmentDTO>> GetAllAppointments();
        Task<AppointmentDTO> GetAppointment(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id);
        Task<AppointmentDTO> CreateAppointment( int docId, int PatientId);

        Task<DoctorDTO> AddDoctor(string firstName, string lastName);
        Task<PatientDTO> AddPatient(string firstName, string lastName);

        Task<bool> CheckExists(bool doctor, int id);


    }
}
