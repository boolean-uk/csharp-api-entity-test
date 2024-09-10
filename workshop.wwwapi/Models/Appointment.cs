﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Key, Column("doctorId")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [Key, Column("patientId")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [Key, Column("perscriptionId")]
        [ForeignKey("Perscription")]
        public int PerscriptionId { get; set; }
        [Column("type")]
        public AppointmentType Type { get; set; }
    }
}
