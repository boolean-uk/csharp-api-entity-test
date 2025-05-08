using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("doctors")]
    [PrimaryKey("Id")]
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }
        [Column("appointments")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        


    }
}
