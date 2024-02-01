using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatientByID(int id);
        Task<Patient> CreatePatient(string fullName);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorByID(int id);
        Task<Doctor> CreateDoctor(string fullName);

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(DateTime booking, Patient patient, Doctor doctor);

    }
}
