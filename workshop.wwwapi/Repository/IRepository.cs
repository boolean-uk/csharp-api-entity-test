using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient?> GetPatientById(int id);

        Task<Patient?> CreateNewPatient(string fullname);

        Task<IEnumerable<Doctor>> GetDoctors();

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
    }
}