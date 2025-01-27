using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Interface;

namespace workshop.wwwapi.Models
{
    [Table("medicines_in_perscriptions")]
    public class MedicinesInPrescription : ICustomModel
    {

        [Column("medicine_id")]
        public int MedicineId { get; set; }
        
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }

        public int quantity { get; set; }
        public string note { get; set; }

        public Prescription Prescription { get; set; }
        public Medicine Medicine { get; set; }

    }
}
