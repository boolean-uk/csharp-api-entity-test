using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        // Patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient entity);

        // Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor entity);

        // Appointments
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> GetAppointmentById(DateTime booking, int doctorId, int patientId);
        Task<Appointment> CreateAppointment(Appointment entity);

        // Medicines & Perscriptions
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> CreatePrescription(Prescription entity);
        //Task<Prescription> AddMedicineToPrescription(int medicineId, int prescriptionId);
        //Task<Appointment> AddPrescriptionToAppointment(int doctorId, int patientId, int prescriptionId);
    }
}
