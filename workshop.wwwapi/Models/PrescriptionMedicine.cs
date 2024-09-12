using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace workshop.wwwapi.Models
{
    [Table("prescription_medicine")]
    public class PrescriptionMedicine
    {
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [Column("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("quantiry")]
        public int? Quantity { get; set; }
        [Column("notes")]
        public string? Notes { get; set; }
    }
}