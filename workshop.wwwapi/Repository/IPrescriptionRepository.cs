using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<Prescription?> GetByAppointmentID(int id);
    }
}
