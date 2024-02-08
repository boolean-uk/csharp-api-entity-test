using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.PrescriptionRepo
{
    public interface IPrescriptionRepository
    {

        Task<IEnumerable<Prescription>> getAllPrescriptions();
    }
}
