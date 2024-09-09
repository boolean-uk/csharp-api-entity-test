using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);
        Task<DoctorDTO> GetDoctor(int id);

        AppointmentDTO CreateAppointment(int month, int day, int doctorId, int patientId);

        List<AppointmentDTO> GetAppointmentsByPatient(int id);

        List<AppointmentDTO> GetAppointments();

        AppointmentDTO GetAppointment(int patientId, int doctorId);

    }
}
