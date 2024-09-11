using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class MedicineDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MedicineDTO(Medicine medicine)
        {
            Id = medicine.Id;
            Name = medicine.Name;
        }
    }


    public class MedicinePrescriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PrescriptionDTO Prescription { get; set; }

        public MedicinePrescriptionDTO(Medicine medicine)
        {
            Id = medicine.Id;
            Name = medicine.Name;
            foreach (MedicinePrescription medicinePre in medicine.MedicinePrescriptions)
            {
                Prescription = new PrescriptionDTO(medicinePre.Prescription);
            }
        }
    }
}