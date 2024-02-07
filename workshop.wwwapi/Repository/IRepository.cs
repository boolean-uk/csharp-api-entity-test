using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //patient
        Task<IEnumerable<PatientDisplayDto>> GetPatients();
        Task<PatientSpecificDto> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientCreate patient);
        Task<bool> PatientIdExists(int id);
        
        //doctor
        Task<IEnumerable<DoctorDisplayDto>> GetDoctors();
        Task<DoctorSpecificDto> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(DoctorCreate doctor);

        //appointment
        Task<List<AppointmentDoctorDto>> GetAppointments();
        Task<AppointmentDoctorDto> GetAppointmentById(int patientId, int doctorId);
        Task<List<AppointmentPatientDto>> GetAppointmentsByPatient(int id);
        Task<List<AppointmentDoctorDto>> GetAppointmentsByDoctor(int id);



    }
}
