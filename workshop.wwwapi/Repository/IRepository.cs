using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatientById(int id);
        Task<PatientDTO> CreatePatient(PatientView patientDTO);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task<DoctorDTO> CreateDoctor(DoctorView doctorDTO);
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id);
        Task<AppointmentDTO> CreateAppointment(AppointmentView appointmentDTO);

    }
}
