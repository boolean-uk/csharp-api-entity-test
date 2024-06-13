using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository
    {
        //Task<Patient> GetPatientById(int patientId);
        //Task<IEnumerable<Patient>> GetPatients();

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Appointment> CreateAppointment(DateTime Booking, int PatientID, int DoctorId);

        Task<IEnumerable<Appointment>> GetAppointmentsById(int id);

    }
}
