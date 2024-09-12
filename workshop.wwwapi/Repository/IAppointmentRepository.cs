using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentByPatient(int id);
        Task<Appointment> GetAppointmentById(int doctorId, int patientId);
        Task<Appointment> CreateAppointment(Appointment appointment);
    }
}
