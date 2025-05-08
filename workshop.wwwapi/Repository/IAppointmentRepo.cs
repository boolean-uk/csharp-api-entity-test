using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepo
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentByDoctor(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentByPatient(int patientId);
        Task<Appointment> GetAppointment(int doctorId, int patientId);

        Task<Appointment> CreateAppointment(Appointment appointment);
    }
}
