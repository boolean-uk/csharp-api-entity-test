using workshop.wwwapi.Models.Domain.Junctions;

namespace workshop.wwwapi.Repository
{
    public interface IPrescriptionMedicineRepository
    {
        Task<IEnumerable<PrescriptionMedicine>> GetAll();
        Task<IEnumerable<PrescriptionMedicine>> GetAllByPrescriptionID(object id);
        Task<PrescriptionMedicine?> Get(object id1, object id2);
        Task<PrescriptionMedicine> Insert(PrescriptionMedicine entity);
        Task<PrescriptionMedicine> Update(PrescriptionMedicine entity);
        Task<PrescriptionMedicine> Delete(object id1, object id2);
    }
}
