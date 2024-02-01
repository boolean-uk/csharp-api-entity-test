using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> PostPatient(Patient patient);

        Task<Patient?> GetPatientById(int id);

        Task<IEnumerable<Doctor>> GetDoctors();

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);


    }
}
