using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatient(int id);
        Task<Patient> CreatePatient(string name);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctor(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<AppointmentDTO> GetAppointmentByDoctorAndPatient(int pasientId, int doctorId);
        Task<AppointmentDTO> GetAppointmentByPatient(int pasientId);
        Task<AppointmentDTO> GetAppointmentByDoctor(int doctorID);

        Task<Appointment> CreateAppointment(int pasientId, int doctorId);


    }
}
