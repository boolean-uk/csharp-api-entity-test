using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOS;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<PatientDTO?> GetPatientById(int id);
        Task<Patient?> AddPatient(string fullname);
    }
}
