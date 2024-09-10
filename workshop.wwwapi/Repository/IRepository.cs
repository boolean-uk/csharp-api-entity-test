using workshop.wwwapi.Models;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient_DTO>> GetPatients();
        Task<IEnumerable<Doctor_DTO>> GetDoctors();
        Task<IEnumerable<Appointment_DTO>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment_DTO>> GetAppointmentsByPatient(int id);
        Task<Patient_DTO> GetPatientById(int id);

        Task<Doctor_DTO> AddDoctor(string doctor);

        Task<Appointment_DTO> AddAppointment(int DoctorId, int PatientId);

        Task<Doctor_DTO> GetDoctorById(int id);

    }
}
