using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{

    public class AppointmentDoctorDto
    {
        public DateTime Booking { get; set; }
        public PatientDoctorDto Patient { get; set; }
    }
}
