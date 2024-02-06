using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> Get();
        Task<Prescription?> Get(int id);
        Task<Prescription?> Create(Prescription prescription);
        Task<Prescription> Update(Prescription prescription);
    }
}
