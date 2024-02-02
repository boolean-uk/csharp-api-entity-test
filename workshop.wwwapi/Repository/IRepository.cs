using workshop.wwwapi.Dto;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDto>> GetPatients();
        Task<PatientDto> GetPatientById(int id);
        Task<PatientDto> CreatePatient(CreatePatientDto createPatientDto);

        Task<IEnumerable<DoctorDto>> GetDoctors();
        Task<DoctorDto> GetDoctorById(int id);
        Task<DoctorDto> CreateDoctor(CreateDoctorDto createdoctorDto);

        Task<IEnumerable<AppointmentDto>> GetAppointments();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatient(int PatientId);
        Task<AppointmentDto> GetAppointmentById(int DoctorId, int PatientId);
        Task<AppointmentDto> CreateAppointment(CreateAppointmentDto appointmentDto);


    }
}
