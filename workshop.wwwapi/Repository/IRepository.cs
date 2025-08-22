using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientPost patient);
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(DoctorPost doctor);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorid);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientid);
        Task<Appointment> CreateAppointment(AppointmentPost appointment);
        Task<IEnumerable<Prescription>> GetPrescriptions();
    }
}
