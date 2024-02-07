using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("doctors")]
    [PrimaryKey("Id")]
    public class Doctor
    {
        [Column("d_id")]
        public int Id { get; set; }
        [Column("d_full_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
