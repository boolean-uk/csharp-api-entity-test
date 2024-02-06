using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("patients")] 
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; } = new List<Appointment>();
    }
}
