using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [PrimaryKey("Id")]
    public class Doctor
    {
        [Column("id")]   
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("appointments")]
        [ForeignKey("appointments")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
