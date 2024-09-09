using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);
        Task<DoctorDTO> GetDoctor(int id);

        Task<AppointmentDTO> CreateAppointment(DateTime time, int doctorId, int patientId);

    }
}
