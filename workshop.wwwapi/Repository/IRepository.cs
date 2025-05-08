using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        //Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription?> GetPrescription(int id);
        Task<Prescription?> CreatePrescription(PostPrescription prescription);
        Task<Appointment?> GetAppointment(int id);
        Task<int> SaveChangesAsync();
    }
}
