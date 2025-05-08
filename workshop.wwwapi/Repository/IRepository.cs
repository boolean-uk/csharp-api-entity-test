using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Payload;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Payload<IEnumerable<PatientGetDTO>>> GetPatients();
        Task<Payload<PatientGetDTO>> GetPatient(int id);
        Task<Payload<PatientGetDTO>> CreatePatient(CreatePatientDTO patient);
        Task<Payload<IEnumerable<DoctorGetDTO>>> GetDoctors();
        Task<Payload<DoctorGetDTO>> GetDoctor(int id);
        Task<Payload<DoctorGetDTO>> CreateDoctor(CreateDoctorDTO doctor);
        Task<Payload<IEnumerable<AppointmentGetDoctor>>> GetAppointmentsByDoctor(int id);
        Task<Payload<IEnumerable<AppointmentGetPatient>>> GetAppointmentsByPatient(int id); 
        Task<Payload<AppointmentGetDTO>> GetAppointment(int id);
        Task<Payload<AppointmentGetDTO>> CreateAppointment(CreateAppointmentDTO appoinmentDTO);
        Task<Payload<IEnumerable<AppointmentGetDTO>>> GetAppointments();
    }
}
