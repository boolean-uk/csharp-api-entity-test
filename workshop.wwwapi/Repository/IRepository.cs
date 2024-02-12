using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(AppointmentCreateDto appointmentCreateDto);
        Task<bool> PatientExists(int id);
        Task<bool> DoctorExists(int id);
        Task<bool> AppointmentExists(int doctorId, int patientId);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescription(int id);
        Task<Prescription> CreatePrescription(int doctorId, int patientId);
        Task<bool> MedicineExists(int id);
        Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescription medicinePrescription);
    }
}
