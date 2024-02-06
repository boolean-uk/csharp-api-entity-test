using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("doctors")]   
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get;} = new List<Appointment>();
    }
}
