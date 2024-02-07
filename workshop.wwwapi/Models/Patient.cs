using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Patient
    {
        [Column("patient_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        // Navigation property for appointments
        public List<Appointment> Appointments { get; set; }
    }
}
