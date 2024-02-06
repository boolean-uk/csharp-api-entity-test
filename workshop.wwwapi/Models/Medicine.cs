using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    [PrimaryKey("Id")]
    public class Medicine
    {
        [Column("me_id")]
        public int Id { get; set; }
        [Column("me_name")]
        public string Name { get; set; }
        [Column("me_quantity")]
        public int Quantity { get; set; }
        [Column("me_instruction")]
        public string Instruction { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; } = new List<MedicinePrescription>();
    }
}
