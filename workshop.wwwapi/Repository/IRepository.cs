using workshop.wwwapi.Data.Post;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> AddPatient(Patient patient);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointment(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment?> AddAppointment(AppointmentPost appointment);

    }
}
