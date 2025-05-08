using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> getAppointmentByDoctor(int doctorId);
        Task<List<Appointment>> getAppointmentByPatient(int patientId);

        Task<List<Appointment>> GetAppointments();
    }
}
