using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{

    public enum PreloadPolicy
    {
        PreloadRelations,
        DoNotPreloadRelations
    }
    public interface IRepository
    {

        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int patientId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Patient?> CreatePatient(string fullname);


        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int doctorId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Doctor?> CreateDoctor(string fullname);


        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);
        Task<Appointment?> GetAppointment(int doctorId, int patientid, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Appointment?> CreateAppointment(int doctorId, int patientId);

        public void SaveChanges();
    }
}
