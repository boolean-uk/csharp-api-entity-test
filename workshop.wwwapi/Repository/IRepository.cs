using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        // Patient
        Task<IEnumerable<PatientDto>> GetPatients();
        Task<PatientDto> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientPost patient, int id);

        // Doctor
        Task<IEnumerable<DoctorDto>> GetDoctors();
        Task<DoctorDto> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(DoctorPost doctor, int id);

        // Appointment
        Task<IEnumerable<AppointmentDto>> GetAppointments();
        Task<AppointmentDto> GetAppointmentById(int doctorId, int patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentByPatient(int patientId);
        Task<Appointment> CreateAppointment(AppointmentPost appointment, int doctorId, int PatientId);


    }
}
