using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<Patient> GetPatientById(int patientId);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<Doctor> GetDoctorById(int doctorId);
        Task<Doctor> CreateDoctor(DoctorDTO doctor);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Patient> CreatePatient(PatientDTO patientDTO);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<PatientDTO> ConvertPatient(Patient patient);
        Task<DoctorDTO> ConvertDoctor(Doctor doctor);
        Task<Appointment> CreateAppointment(int doctorId, int patientId);
    }
}
