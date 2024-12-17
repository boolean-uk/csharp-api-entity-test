using workshop.wwwapi.Dtoes.ViewModels;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //Patients
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetSinglePatient(int id);
        Task<Patient> CreatePatient(Patient patient);

        //Doctors
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetSingleDoctor(int id);
        Task<Doctor> CreateDoctor(Doctor dct);
 

        //Appointments
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<Appointment> GetSingleAppointment(int doctorId, int patientId);
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(Appointment appointment);

    }
}
