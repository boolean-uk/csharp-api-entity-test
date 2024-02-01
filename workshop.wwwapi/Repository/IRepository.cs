using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{

    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int patientId);
        Task<Patient?> CreatePatient(string fullname);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Appointment?> AddAppointment(Patient patient, Doctor doctor, DateTime appointmentDate);
        Task<Doctor?> GetDoctor(int doctorId);
        Task<Doctor?> CreateDoctor(string fullName);

    }
}
