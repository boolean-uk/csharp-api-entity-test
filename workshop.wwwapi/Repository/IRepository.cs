using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Patient> GetPatientById(int id);

        Task<IEnumerable<Appointment>> GetAppointments();

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Appointment> GetAppointmentById(int doctor_id, int patient_id);
    }
}
