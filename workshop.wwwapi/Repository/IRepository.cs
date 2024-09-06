using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(Guid id);

        Task<Patient> CreatePatient(Patient patient);

        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(Guid id);


    }
}
