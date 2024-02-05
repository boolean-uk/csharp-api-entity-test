using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO?> GetPatientById(int id);
        Task<PatientDTO?> CreatePatient(CreatePatientDTO cDTO);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO?> GetDoctorById(int id);
        Task<DoctorDTO?> CreateDoctor(CreateDoctorDTO cDTO);
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientId(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorId(int id);
        Task<AppointmentDTO?> GetAppointmentByIds(int doctorid, int patientid);
        Task<IEnumerable<PrescriptionDTO>> GetPrescriptions();
        Task<int> CreatePrescription(CreatePrescriptionDTO cDTO);
    }
}
