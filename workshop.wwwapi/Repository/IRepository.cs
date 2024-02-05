using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatientByID(int id);
        Task<Patient> CreatePatient(string name);
        
        //doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorByID(int id);
        Task<Doctor> CreateDoctor(string name);

        //appointments
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment?>> GetAppointmentsByDoctorID(int id);
        Task<IEnumerable<Appointment?>> GetAppointmentsByPatientID(int id);
        Task<Appointment> CreateAppointment(int doctorId, int patientId, DateTime appointmentTime);
    }
}