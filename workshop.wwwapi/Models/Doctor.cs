using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("appointments")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
