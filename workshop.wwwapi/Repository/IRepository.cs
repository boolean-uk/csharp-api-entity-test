using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Patient> GetPatientById(int id);
        Task<int> GetLastPatientId();
        Task<Patient> AddPatient(Patient patient);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<int> GetLastAppointmentId();
        Task<int> GetLastDoctorId();
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
    }
}
