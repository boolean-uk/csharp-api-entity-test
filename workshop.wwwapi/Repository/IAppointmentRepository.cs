using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetByDoctorID(object id);
        Task<IEnumerable<Appointment>> GetByPatientID(object id);
    }
}
