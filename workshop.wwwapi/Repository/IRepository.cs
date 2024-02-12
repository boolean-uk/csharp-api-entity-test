using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<PatientDto> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientDto patientDto);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(DoctorDto doctorDto);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int patientId , int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int id);
        Task<Appointment> CreateAppointment(AppointmentDto appointmentDto);
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> CreateMedicine(Medicine medicine);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> CreatePrescription(Prescription prescription);
        Task<Prescription> AttachMedicineToPrescription(int prescriptionId , int medicineId , int quantity , string notes);

    }
}
