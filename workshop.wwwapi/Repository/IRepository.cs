using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByComposite(int patientId, int doctorId);


    }
}
