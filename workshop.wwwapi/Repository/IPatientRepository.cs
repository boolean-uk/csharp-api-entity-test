using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatient(int id);
        Task<PatientDTO> CreatePatient(PatientDTO patient);

    }
}
