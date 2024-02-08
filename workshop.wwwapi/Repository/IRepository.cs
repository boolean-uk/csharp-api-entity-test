using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //-------- Patient ------------
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatientbyId(int id);
        Task<Patient> CreatePatient(Patient patient);

        //--------- Doctor ---------------
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);

        //--------- Appointment --------------
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id);

        //-------------------------- Medicine & Prescription -----------------------------
        Task<IEnumerable<MedicineDTO>> GetAllMedicines();
        Task<IEnumerable<PrescriptionDTO>> GetAllPrescriptions();
        Task<Prescription> CreatePrescription(Prescription prescription); 
        Task<PrescriptionDTO> AddMedicineToPrescription(int medicineId, int prescriptionId);
        Task<AppointmentDTO> AddPrescriptionToAppointment(int doctorId, int patientId, int prescriptionId);


    }
}
