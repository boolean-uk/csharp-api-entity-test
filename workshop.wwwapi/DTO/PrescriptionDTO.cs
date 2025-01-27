using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public SimplifiedDocDTO doctor { get; set; }
        public SimplifiedPatientDTO patient { get; set; }
        public AppointmentDTO appointment { get; set; }
        public MedicineDTO medicine {  get; set; }
    }
}
