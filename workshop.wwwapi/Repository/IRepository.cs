using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetAPatient(int id);
        Task<Patient> CreatePatient(string name);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetADoctor(int id);
        Task<Doctor> CreateDoctor(string name);
        Task<IEnumerable<Appointment>> GettAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByIds(int DId, int PId);
        Task<Appointment> CreateAppointment(int Doc_id, int Pat_id);
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetAPrescription(int id);
        Task<Prescription> CreatePrescription(int Doc_id, int Pat_id);
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetAMedicine(int id);
        Task<Medicine> CreateMedicine(string name);


    }
}
