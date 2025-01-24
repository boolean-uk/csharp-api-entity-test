using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        // For some reason I had to comment out [Key] here and use modelBuilder.Entity<Appointment>().HasKey(a => a.Id); in DatabaseContext.cs.
        //[Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("appointment_date_time")]
        public DateTime AppointmentDateTime { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
