using workshop.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId);
        Task<Appointment> GetAppointmentDetails(int patientId, int doctorId);
    }
}
