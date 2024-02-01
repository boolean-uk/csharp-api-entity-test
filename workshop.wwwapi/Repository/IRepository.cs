using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Patient> AddPatient(AddPatientDTO dto);
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddDoctor(GetDoctorDTO dto);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> GetAppointmentById(int patientId, int doctorId);
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> AddAppointment(AddAppointmentDTO dto);
    }
}
