using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {
        
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }

    public class DoctorDisplayDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    
}
