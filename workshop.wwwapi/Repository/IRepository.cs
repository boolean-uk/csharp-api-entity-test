using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(Guid id);
        Task<Patient> CreatePatient(Patient patient);

        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(Guid id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(Guid patientId, Guid doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(Guid id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(Guid id);

        Task CreateAppointment(Appointment appointment);

        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescription(Guid id);

        Task CreatePrescription(Prescription prescription);

        Task AddMedicineToPrescription(Guid medicineId, Guid prescriptionId);

        Task<Medicine> GetMedicine(Guid id);
    }
}
