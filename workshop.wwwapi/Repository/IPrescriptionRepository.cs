using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetPrescriptions();
        
        Task<Prescription?> CreatePrescription(List<int> MedcinesId);
        Task<Prescription?> DeletePrescriptionById(int PrescriptionId);
        Task<Prescription?> AddPrescriptionToAppointment(int PrescriptionId, int AppointmendId);

    }
}