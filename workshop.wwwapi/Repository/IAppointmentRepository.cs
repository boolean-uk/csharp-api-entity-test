using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> Get();
        Task<Appointment?> Get(int id);
        Task<IEnumerable<Appointment>> GetByDoctor(int id);
        Task<IEnumerable<Appointment>> GetByPatient(int id);
        Task<IEnumerable<Appointment>> GetByDoctorAndPatient(int doctorId, int patientId);
        Task<Appointment?> Create(Appointment appointment);
    }
}
