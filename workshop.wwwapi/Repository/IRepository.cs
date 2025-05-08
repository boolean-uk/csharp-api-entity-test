using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> CreatePatient(string name);


        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctor(int id);
        Task<Doctor> CreateDoctor(string name);


        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment?> GetAppointment(string booking);
        Task<Appointment> CreateAppointment(string booking, int patientId, int doctorId);

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription?> GetPrescription(int id);
        Task<Prescription> CreatePrescription(string name, int quantity, string notes);

        Task<IEnumerable<Medicine>> GetMedicines();
    }
}
