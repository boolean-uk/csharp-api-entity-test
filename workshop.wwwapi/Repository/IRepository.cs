using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{

    public enum PreloadPolicy
    {
        DoNotPreloadRelations,
        PreloadRelations
    }
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Patient?> CreatePatient(string fullName);



        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Doctor?> CreateDoctor(string fullName);
        

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> CreateAppointment(DateTime booking, Doctor doctor, Patient patient);

        Task<Appointment?> GetAppointmentByPatientId(int patientId);
        Task<Appointment?> GetAppointmentByDoctorId(int doctorId);
    }
}
