using System.Threading.Tasks;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        public Task<Patient?> GetPatient(int patientId);
        public Task<Patient> CreatePatient(Patient newPatient);
        public Task<Doctor?> GetDoctor(int doctorId);
        public Task<Doctor> CreateDoctor(Doctor newDoctor);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<IEnumerable<Appointment>> GetAppointments();
        public Task<Appointment> CreateAppointment(Appointment newAppointment);
    }
}
