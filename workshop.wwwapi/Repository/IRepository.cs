using workshop.wwwapi.DTOs.Extension;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Post;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //PATIENTS
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id);
        Task<Patient> CreatePatient(PatientPost model);


        //DOCTORS
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor?> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(DoctorPost model);


        //APPOINTMENTS
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> CreateAppointment(AppointmentPost model);


        //MEDICINEPRESCRIPTIONS
        Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptions();
        Task<MedicinePrescription> GetMedicinePrescriptionsById(int id);
        Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescriptionPost model);

        //NEEDED FOR MEDICINEPRESCRIPTIONS TO WORK PROPERLY
        Task<Medicine> GetMedicineById(int id);
        Task<Prescription> GetPrescriptionById(int id);
        Task<Appointment> GetAppointmentById(int id);
    }
}
