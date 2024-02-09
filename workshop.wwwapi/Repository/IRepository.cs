using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id);
        Task<Patient?> AddPatient(string full_name);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorById(int id);
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment?> GetAppointmentWithDetailsById(int appointmentId);
        Task<List<Appointment>?> GetAppointmentsByDoctorId(int doctorId);

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Appointment?> assignAppointment(int patient_id, int doc_id);
    }
}
