using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class AppointmentAppointmentDto
    {

        public DateTime Booking { get; set; }

        public DoctorAppointmentDto Doctor { get; set; }

        public PatientAppointmentDto Patient { get; set; }
    }
}


