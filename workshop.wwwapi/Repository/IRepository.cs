using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Patient> GetPatientById(int id);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentByDoctorId(int id);
        Task<IEnumerable<Appointment>> GetAppointmentByPatientId(int id);
        Task<IEnumerable<Prescription>>GetPrescriptions();
        Task<MedicinePrescription>GetMedicinePrescriptionsById(int id);
        Task<Prescription> CreatePrescription(Appointment appointment, MedicinePrescription meds);
        Task<IEnumerable<Medicine>> GetMedicines();
    }
}
