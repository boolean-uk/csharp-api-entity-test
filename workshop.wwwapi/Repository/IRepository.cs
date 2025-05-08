using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient?> CreatePatient(string name);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        Task<Doctor?> CreateDoctor(string name);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(int DoctorId, int PatientId);
    }
}
