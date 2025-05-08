using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTOs
{
    [Table("prescription_medicine")]
    public class PrescriptionMedicine
    {
        [ForeignKey("meidcine_id")]
        public int MedicineId { get; set; }


        [ForeignKey("prescription_id")]
        public int PrescriptionId { get; set; }
       
        

    }
}
