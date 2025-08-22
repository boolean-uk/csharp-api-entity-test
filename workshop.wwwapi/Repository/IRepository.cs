using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<Patient> AddAsync(Patient patient);
        Task<Doctor> AddAsync(Doctor doctor);
        Task<Appointment> AddAsync(Appointment appointment);

    }
}
