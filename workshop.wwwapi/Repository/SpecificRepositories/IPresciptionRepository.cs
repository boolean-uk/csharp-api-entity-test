using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.GenericRepositories;

namespace workshop.wwwapi.Repository.SpecificRepositories
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<Prescription> GetPrescriptionWithDetails(int id);
        Task<IEnumerable<Prescription>> GetPrescriptionsByAppointmentId(int patientId, int doctorId);
    }
}
