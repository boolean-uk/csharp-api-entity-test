using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("medicine_prescriptions")]
    public class MedicinePrescription
    {
        [Column("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("prescription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }

    public class MedicineInPrescriptionDTO
    {
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public string note { get; set; }

        public MedicineInPrescriptionDTO(MedicinePrescription medicinePrescription)
        {
            MedicineName = medicinePrescription.Medicine.Name;
            Quantity = medicinePrescription.Medicine.quantity;
            note = medicinePrescription.Medicine.Notes;
        }
    }
}
