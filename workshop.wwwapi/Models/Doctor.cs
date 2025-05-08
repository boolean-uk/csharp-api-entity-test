using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("doctor")]
    [PrimaryKey("Id")]
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("doctor_appointments")]
        [JsonIgnore]
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
