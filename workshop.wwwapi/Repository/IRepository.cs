using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //Patients 
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);

        //Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);

        //Appointment
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentsById(int doctorId, int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentByDoctorId(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int id);

        //Prescriptions 
        Task<IEnumerable<Prescription>> GetPrescriptions();


        //PrescriptionMedicine

        Task<IEnumerable<PrescriptionMedicine>> GetPrescriptionMedicines();
        Task<PrescriptionMedicine> CreatePrescriptionMedicine(PrescriptionMedicine prepMed);

    }
}
