using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Interface;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine : ICustomModel
    {
        [Key, Column("id")]
        public int Id { get; set; }
        public string name { get; set; }

        public List<MedicinesInPrescription> MedicinesInPrescriptions { get; set; }
    }
}
