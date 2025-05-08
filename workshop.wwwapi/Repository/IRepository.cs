using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<Appointment> GetAppointment(int patientId, int DoctorId);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescription(int id);
        Task<Prescription> CreatePrescription(Prescription prescription);
        Task<Prescription> UpdatePrescription(Prescription prescription);
        Task<Medicine> GetMedicine(int id);
        Task<Prescription> GetConnection(PrescriptionMedicine prescriptionMedicine);
        Task<PrescriptionMedicine> GetMedicinePrescription(int prescriptionId, int medicineId);
    }
}
