using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace workshop.wwwapi.Models
{
    [Table("perscription_medicine")]
    public class PerscriptionMedicine
    {
        
        [Column("perscription_id")]
        public int PerscriptionId { get; set; }

        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Column("quantiry")]
        public int Quantiry { get; set; }
    }
}