using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PrescriptionDTO(Prescription prescription)
        {
            Id = prescription.Id;
            Name = prescription.Name;
        }
    }
}