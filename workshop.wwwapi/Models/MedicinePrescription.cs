using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine_prescriptions")]
    public class MedicinePrescription
    {
        [Column("medicine_id")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        [Column("prescription_id")]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("usage")]
        public string Usage { get; set; }

        public MPDataDto ToDataDto()
        {
            return new MPDataDto
            {
                Name = Medicine.Name,
                Quantity = Quantity,
                Usage = Usage,
            };
        }
    }

    public struct MPDataDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Usage { get; set; }
    }

    public struct MPInputDto
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string Usage { get; set; }
    }
}
