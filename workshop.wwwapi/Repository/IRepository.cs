using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Patient> GetAEnitityById(int id);
        Task <Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Patient>> GetPatients();
        Task<Doctor> MakeDoctor(Doctor doctor);
        Task<Patient> MakePatient(Patient patient);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);



    }
}
