using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task <Patient> GetPatient(int id);
        Task <Doctor>GetDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task <Appointment>GetAppointment(int id);
        Task <Doctor>GetDoctorsAppointments(int id);
    }
}
