using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        // Patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);

        // Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);

        // Appointments
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);
        Task<Appointment> CreateAppointment(Appointment appointment);
    }
}
