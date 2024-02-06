﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Domain
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<PrescriptionMedicine> Prescriptions { get; set; }
    }
}
