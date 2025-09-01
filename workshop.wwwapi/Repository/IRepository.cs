using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        // Patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        
        // Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        
        // Appointments
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);

    }
}