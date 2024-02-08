using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace workshop.wwwapi.Models
{
    [Table("perscription_medicine")]
    public class PrescriptionMedicine
    {
        
        [Column("perscription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }        

        [Column("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("quantiry")]
        public int Quantiry { get; set; }
    }
}