using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();

        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorid);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientid);

    }
}
