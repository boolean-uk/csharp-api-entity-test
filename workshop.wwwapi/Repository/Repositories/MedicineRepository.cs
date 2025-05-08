using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository.Repositories
{
    public class MedicineRepository : IRepository<Medicine>
    {
        DatabaseContext db;
        public MedicineRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public Task<Medicine> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<Medicine?> Get(object id)
        {
            return await db.Medicines.FirstOrDefaultAsync(m => m.ID == (int)id);
        }

        public Task<IEnumerable<Medicine>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Medicine> Insert(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public Task<Medicine> Update(Medicine entity)
        {
            throw new NotImplementedException();
        }
    }
}
