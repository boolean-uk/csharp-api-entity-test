using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patient")]
    [PrimaryKey("Id")]
    public class Patient
    {
        [Column("patient_id")]
        
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("patient_appointments")]
        [JsonIgnore]
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
