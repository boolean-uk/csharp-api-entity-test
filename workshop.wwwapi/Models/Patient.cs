using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    [Table("patients")]
    [PrimaryKey("Id")]
    public class Patient
    {
        [Column("p_id")]
        public int Id { get; set; }
        [Column("p_full_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
