using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    [Table("medicine")]
    [PrimaryKey("Id")]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("instructions")]
        public string Instructions { get; set; }

        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
