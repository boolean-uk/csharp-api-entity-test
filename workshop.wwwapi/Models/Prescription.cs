using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    [PrimaryKey("Id")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
