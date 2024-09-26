using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient?> GetPatient(int id); 
        Task<Patient> CreateAPatient(string fullName);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorsByID(int id);


        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointmentsByID(int doctorID, int patientID);
        Task<IEnumerable<Appointment?>> GetAppointmentsByDoctorID(int doctorId);
        Task<IEnumerable<Appointment?>> GetAppointmentsByPatientID(int patientId);
        Task<Appointment?> CreateAppointment(DateTime date, int patientId, int doctorId);
    }
}
