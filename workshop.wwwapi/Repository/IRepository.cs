using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> CreatePatient(Patient entity);
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> CreateDoctor(Doctor entity);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> CreateAppointment(Appointment entity);
        Task<IEnumerable<Appointment>> GetAppointmentById(int doctorID, int patientID);
        //Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
    }
}
