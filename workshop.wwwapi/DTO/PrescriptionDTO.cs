using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        

        public PrescriptionDTO(Prescription prescription)
        {
            Id = prescription.Id;
            Quantity = prescription.Quantity;
            Notes = prescription.Notes;
        }
    }

    public class PrescriptionMedicineDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public MedicineDTO Medicine { get; set; }

        public PrescriptionMedicineDTO(Prescription prescription)
        {
            Id = prescription.Id;
            Quantity = prescription.Quantity;
            Notes = prescription.Notes;
            foreach (MedicinePrescription medicinePre in prescription.MedicinePrescriptions)
            {
                Medicine = new MedicineDTO(medicinePre.Medicine);
            }
        }
    }
}