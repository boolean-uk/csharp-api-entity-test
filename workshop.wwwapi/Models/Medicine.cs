using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [PrimaryKey(nameof(Id))]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("instruction")]
        public string Instruction { get; set; }

        [Column("prescriptions")]
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
