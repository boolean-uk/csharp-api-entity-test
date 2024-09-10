using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);

        Task<IEnumerable<AppointmentDTO>> GetAllAppointments();
        Task<AppointmentDTO> GetAppointment(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id);
        Task<AppointmentDTO> CreateAppointment( int docId, int PatientId);

        Task<DoctorDTO> AddDoctor(string firstName, string lastName);
        Task<PatientDTO> AddPatient(string firstName, string lastName);

        //0 is doctor, 1 is patient, 2 is prescription, 3 is appointment, 4 is medince
        Task<bool> CheckExists(int type, int id);

        Task<PrescriptionDTO> CreatePrescription(int appointmentId, List<int> medicinIds);

        Task<PrescriptionDTO> GetPrescription(int id);

        Task<IEnumerable<PrescriptionDTO>> GetPrescriptions();
    }
}
