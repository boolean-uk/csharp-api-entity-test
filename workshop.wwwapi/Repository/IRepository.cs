using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> AddPatient(Patient patient);

        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddDoctor(Doctor doctor);

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);
        Task<Appointment> AddAppointment(Appointment appointment);

        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> AddPrescription(Prescription prescription, MedicineOnPrescription medicineOnPrescription);
    }
}
