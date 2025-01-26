using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetAPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetADoctor(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<Appointment> GetAppointment(int patientId, int doctorId);
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);


    }
}
