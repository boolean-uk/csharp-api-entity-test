﻿using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("type")]
        public AppointmentType Type { get; set; }
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }

    public enum AppointmentType
    {
        InPerson, 
        Online,
        Double
    }
}
