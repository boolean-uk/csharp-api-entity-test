using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    //

    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("patient_id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("appointments")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Patient(PatientPost model)
        {
            FullName = model.FullName;
            Appointments = new List<Appointment>();
        }

        public Patient()
        {
            
        }
    }
}
