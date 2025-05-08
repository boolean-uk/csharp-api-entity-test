using workshop.wwwapi.DTO.Client;
using workshop.wwwapi.DTO.Server;
using workshop.wwwapi.Models;
using workshop.wwwapi.StatusPayloads;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient_server_dto>> GetPatients();
        Task<Payload<patientAndDoctor_dto>> GetAPatient(int id);
        Task<Patient_server_dto> CreatePatient(patient_client_dto patientInfo);
        Task<IList<doctor_server_dto>> GetDoctors();
        Task<Payload<doctorAndPatient>> GetADoctor(int id);
        Task<createDoctor_dto> CreateDoctor(createDoctor_dto doctorInfo);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IList<appointment_server_dto>> GetAppointments();
        Task<Payload<anAppointment>> GetAnAppointment(int doctorId, int patientId);
        Task<Payload<List<anAppointment>>> GetApointmentByDoctorId(int id);
        Task<Payload<List<anAppointment>>> GetApointmentByPatientId(int id);
        Task<List<perscription_server_dto>> GetPerscriptions();        
        Task<Payload<Perscription>> CreatePerscription(perscription_create_dto perscriptionDetails);
        bool test();


    }
}
