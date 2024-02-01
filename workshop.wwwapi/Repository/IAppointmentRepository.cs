using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> GetAppointmentById(int patientId, int doctorId);
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> AddAppointment(AddAppointmentDTO dto);
    }
}
