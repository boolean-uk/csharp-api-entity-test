using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    

    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fullName")]
        public string FullName { get; set; }

        [JsonIgnore] // Todo: replace this with DTO approach
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}

 
