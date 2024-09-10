using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId);

        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId);
        Task<Appointment> CreateAppointment(Appointment appointment);
    }
}
