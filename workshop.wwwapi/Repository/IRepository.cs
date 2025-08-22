using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        // Patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient patient);

        // Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);

        // Appointments
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);

        // Prescriptions
        Task<ICollection<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> CreatePrescription(Prescription prescription);
        //Task<Prescription> SetAppointmentToPrescription(int appointmentId);

        // Medicines
        //Task<Medicine> GetMedicineById(int id);
        //Task<ICollection<Medicine>> GetMedicines();
    }
}
