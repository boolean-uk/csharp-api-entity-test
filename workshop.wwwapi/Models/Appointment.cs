﻿using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
       
        [Column("booking")]
        public DateTime appointmentDate { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        

    }
}
