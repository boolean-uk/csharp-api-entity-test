using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> Get();
        Task<Medicine?> Get(int id);
        Task<Medicine> Create(Medicine medicine);
        Task<Medicine> Update(Medicine medicine);
    }
}
