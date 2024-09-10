using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<PatientDTO>> GetPatients();
        Task<PatientDTO> GetPatient(int id);
        Task<PatientDTO> AddPatient(Patient entity);
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctor(int id);
        Task<DoctorDTO> AddDoctor(Doctor entity);
        Task<IEnumerable<AppointmentDTO>> GetAppointments();
        Task<AppointmentDTO> GetAppointment(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id);
        Task<AppointmentDTO> AddAppointment(Appointment entity);
        Task<IEnumerable<PerscriptionDTO>> GetPerscriptions();
        Task<PerscriptionDTO> AddPerscription(Perscription entity);
        Task<PerscriptionDTO> UpdatePerscription(int id, List<int> medicineIds);
        Task<AppointmentDTO> AttachPerscription(int perscriptionId, int appointmentId);
        Task<IEnumerable<MedicineDTO>> GetMedicines();
    }
}
