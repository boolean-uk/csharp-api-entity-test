using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPerscriptionRepository
    {

        Task<List<Perscription>> GetAllPerscriptions();
        
        Task<Perscription> GetOne(int id);

        Task Create(Perscription entity);

        Task InjectToAppointment (int appointmentId, int perscriptionId);

        Task<List<Medicine>> GetMedicinesByPrescriptionIdAsync(int id);

        Task<Medicine> GetMedicineById(int id);

    }
}
