using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //Patient methods
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(string name);
        //Doctor methods
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(string name);
        //Appointment methods
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentById(int docID, int patID);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Appointment> CreateAppointment(int doctor_id, int patient_id);


    }
}
