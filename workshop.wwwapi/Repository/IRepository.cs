using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOS;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<DoctorBaseDTO?> GetDoctorById(int id);
        Task<IEnumerable<DoctorBaseDTO>> GetDoctors();
        Task<Doctor?> AddDoctor(string fullname);

        Task<IEnumerable<PatientBaseDTO>> GetPatients();
        Task<PatientBaseDTO?> GetPatientById(int id);
        Task<Patient?> AddPatient(string fullname);

        Task<IEnumerable<AppointmentPatientDTO?>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<AppointmentDoctorDTO?>> GetAppointmentsByPatient(int id);
        Task<AppointmentFullDTO?> GetAppointmentById(int doctorId, int patientId);
        Task<IEnumerable<AppointmentFullDTO?>> GetAppointments();
        Task<Appointment?> AddAppointment(int doctorId, int patientId);
    }
}