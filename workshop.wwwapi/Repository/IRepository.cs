using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //Patient
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientPost patient, int id);


        //Doctors
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task<DoctorDTO> CreateDoctor(CreateDoctorDTO createdoctorDTO);



        //Appointments
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int DoctorId);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int PatientId);


  
        Task<AppointmentDTO> GetAppointmentById(int DoctorId, int PatientId);
        Task<AppointmentDTO> CreateAppointment(CreateAppointmentDTO appointmentDTO);

        
    }
}
