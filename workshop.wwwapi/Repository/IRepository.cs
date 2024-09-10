using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Patient> GetPatientById(int id);
        Task<Patient> AddPatient(int id, string name);
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddDoctor(int id, string name);
        Task<Appointment> AddAppointment(int doctorId, int patientId, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
    }
}
