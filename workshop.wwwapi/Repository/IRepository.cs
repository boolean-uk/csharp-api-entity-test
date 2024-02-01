using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> PostPatient(Patient patient);

        Task<Patient?> GetPatientById(int id);

        Task<IEnumerable<Doctor>> GetDoctors();

        Task<Doctor?> GetSpecificDoctor(int id);

        Task<Doctor> PostDoctor(Doctor doctorInput);

        Task<IEnumerable<Appointment>> GetAppointments();

        Task<IEnumerable<Appointment>> GetAppointmentsForDoctors(int id);

        Task<IEnumerable<Appointment>>  GetAppointmentsForPatients(int id);

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);


    }
}
