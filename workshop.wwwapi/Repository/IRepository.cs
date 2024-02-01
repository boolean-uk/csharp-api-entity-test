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
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id);
    }
}
