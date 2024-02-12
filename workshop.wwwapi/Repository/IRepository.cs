using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task <Patient> GetPatient(int id);
        Task <Doctor>GetDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task <Appointment>GetAppointment(int id);
        Task<Doctor> GetDoctorWithAppointments(int id);
        Task<Patient> GetPatientWithAppointments(int id);
        Task<Appointment> AddAppointment(PostAppointment appointment);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> AddPrescription(Prescription P);
    }
}
