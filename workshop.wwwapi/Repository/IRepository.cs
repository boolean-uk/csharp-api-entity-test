using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> GetPatientById(int id);

        Task<Patient> CreatePatient(PostPatient patient);
        Task<IEnumerable<Doctor>> GetDoctors();

        Task<Doctor> GetDoctorById(int id);

        Task<Doctor> CreateDoctor(PostDoctor doctor);

        Task<IEnumerable<Appointment>> GetAppointments();

        Task<Appointment> GetAppointmentById(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<Appointment> CreateAppointment(PostAppointment app);



    }
}
