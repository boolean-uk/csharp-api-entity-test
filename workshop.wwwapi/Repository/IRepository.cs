using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOS;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<DoctorDTO?> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> AddDoctor(string fullname);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Patient>> GetPatients();
        Task<PatientDTO?> GetPatientById(int id);
        Task<Patient?> AddPatient(string fullname);
    }
}
