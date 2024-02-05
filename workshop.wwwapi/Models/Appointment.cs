using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    //The assignment has a weakness. A composite key of a_fk_doctor_id and a_fk_patient_id makes it so a doctor can only treat a patient once. I added a primary key to the table
    //instead of having three composites. That seems like overkill.
    [Table("appointments")]
    [PrimaryKey("Id")]
    public class Appointment
    {
        [Column("a_id")]
        public int Id { get; set; }

        [Column("a_fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("a_fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("a_booking")]
        public DateTime Booking { get; set; }
    }
}
