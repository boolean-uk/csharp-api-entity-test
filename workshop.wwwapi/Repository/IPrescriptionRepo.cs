using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPrescriptionRepo
    {
        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> CreatePrescription(Prescription newPrescription);
    }
}
