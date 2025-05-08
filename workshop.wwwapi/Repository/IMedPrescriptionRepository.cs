using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{

    public interface IMedPrescriptionRepository
    {


        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription?> GetPrescription(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Prescription?> CreatePrescription(int medId, int quantity, string notes);

        Task<Appointment?> AttachPrescriptionToAppointment(int presId, int doctorId, int patientId);


        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine?> GetMedicine(int id);
        Task<Medicine?> CreateMedicine(string name);

        public void SaveChanges();
    }
}
