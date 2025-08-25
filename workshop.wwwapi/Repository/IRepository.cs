using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Patient>> GetPatients();
        public Task<Patient> GetOnePatient(int id);
        public Task<Patient> CreatePatient(Patient patient);

        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> GetOneDoctor(int id);
        public Task<Doctor> CreateDoctor(Doctor doctor);

        public Task<IEnumerable<Appointment>> GetAppointments();
        public Task<Appointment> GetAppointmentById(int id);
        public Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        public Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        public Task<Appointment> CreateAppointment(Appointment appointment);


    }
}
