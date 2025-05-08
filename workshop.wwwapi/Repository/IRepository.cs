using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Patient> GetPatientById(int id);
        public Task<Patient> CreatePatient(string name);
        public Task<Doctor> CreateDoctor(string name);

        public Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        public Task<Appointment> CreateAppointment(int doctorid, int patientid, DateTime booking, AppointmentType type);

        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<Appointment?> GetAppointmentsByCompositeId(int doctorid, int patientid, DateTime booking);
    }
}
