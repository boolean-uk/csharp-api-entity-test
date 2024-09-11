
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models {

    [Table("prescriptions")]
    public class Prescription {
        [Column("id")]
        public int Id {get; set;}
        [Column("appointment_id")]
        public int AppointmentID {get; set;}
        public Appointment appointment {get; set;} = null!;
        public ICollection<Medicine> Medicines {get; set;} = [];
    }
}