using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> CreateDoctor(DoctorPost doctor);
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(PatientPost patient);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int id);
        Task<Appointment> CreateAppointment(AppointmentPost appointment);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
    }
}
