using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Interface;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription :ICustomModel
    {
        [Key, Column("id")]
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public List<MedicinesInPrescription> MedicinesInPrescription { get; set; }
        
    }
}
