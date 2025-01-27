using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int i);
        Task<Patient?> CreatePatient(PatientPostDto patient);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        Task<Doctor?> CreateDoctor(DoctorPostDto doctor);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<Appointment?> CreateAppointment(AppointmentPostDto appointment);
    }
}
