using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("appointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [Column("doctorid")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Column("patientid")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Column("appointmentType")]
        public AppointmentType AppType { get; set; }


    }
}
