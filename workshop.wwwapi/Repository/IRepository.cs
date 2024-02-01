using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Patient> AddPatient(AddPatientDTO dto);
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatients();
        //Task<IEnumerable<Doctor>> GetDoctors();
        //Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);


    }
}
