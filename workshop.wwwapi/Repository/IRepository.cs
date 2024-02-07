using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDisplayDto>> GetPatients();
        Task<PatientSpesificDto> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientCreate patient);
        Task<bool> PatientIdExists(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<List<DoctorAppointmentDto>> GetAppointmentsByDoctor(int id);


    }
}
