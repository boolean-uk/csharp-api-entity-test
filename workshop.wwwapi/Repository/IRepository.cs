using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionbyId(int id);
        Task<Prescription> CreatePrescription(Prescription prescription);
        Task<PrescribedMedicine> CreatePrescribedMedicide(PrescribedMedicine prescribed);

    }
}
