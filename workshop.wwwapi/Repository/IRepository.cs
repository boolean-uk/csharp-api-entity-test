using System.Linq.Expressions;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(string fullName);


        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(string fullName);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int id);

        Task<Appointment> GetAppointmentByIds(int patientId, int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
       
    }
}
